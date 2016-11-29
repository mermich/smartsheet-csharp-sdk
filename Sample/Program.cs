﻿using Smartsheet.Api;
using Smartsheet.Api.Models;
using Smartsheet.Api.OAuth;
using System;
using System.Collections;
using System.Collections.Generic;

namespace sdk_csharp_sample
{
	public class Program
	{
		public Program()
		{
		}

		public static void Main(string[] args)
		{
			SampleCode();
			//OAuthExample();
		}

		public static void OAuthExample()
		{

			// Setup the information that is necessary to request an authorization code
			OAuthFlow oauth = new OAuthFlowBuilder().SetClientId("cxggphqv52axrylaux").SetClientSecret("1lllvnekmjafoad0si").
				SetRedirectURL("https://batie.com/").Build();

			// Create the URL that the user will go to grant authorization to the application
			string url = oauth.NewAuthorizationURL(new Smartsheet.Api.OAuth.AccessScope[] { Smartsheet.Api.OAuth.AccessScope.CREATE_SHEETS, Smartsheet.Api.OAuth.AccessScope.WRITE_SHEETS }, "key=YOUR_VALUE");

			// Take the user to the following URL
			Console.WriteLine(url);

			// After the user accepts or declines the authorization they are taken to the redirect URL. The URL of the page
			// the user is taken to can be used to generate an AuthorizationResult object.
			string authorizationResponseURL = "https://batie.com/?code=dxe7eykuh912rhs&expires_in=239824&state=key%3DYOUR_VALUE";

			// On this page pass in the full URL of the page to create an authorizationResult object  
			AuthorizationResult authResult = oauth.ExtractAuthorizationResult(authorizationResponseURL);

			// Get the token from the authorization result
			Token token = oauth.ObtainNewToken(authResult);

			// Save the token or use it.
		}

		public static void SampleCode()
		{
			// Set the Access Token
			Token token = new Token();
			token.AccessToken = "YOUR_TOKEN";

			// Use the Smartsheet Builder to create a Smartsheet
			SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(token.AccessToken).Build();

			if (false)
			{
				// List all contents (specify 'include' parameter with value of "source").
				Home home = smartsheet.HomeResources.GetHome(new HomeInclusion[] { HomeInclusion.SOURCE });

				// List folders in "Sheets" folder (specify 'includeAll' parameter with value of "true").
				IList<Folder> homeFolders = home.Folders;
				foreach (Folder tmpFolder in homeFolders)
				{
					Console.WriteLine("folder:" + tmpFolder.Name);
				}

				// List sheets (omit 'include' parameter and pagination parameters).
				PaginatedResult<Sheet> homeSheetsResult = smartsheet.SheetResources.ListSheets(null, null);
				foreach (Sheet tmpSheet in homeSheetsResult.Data)
				{
					Console.WriteLine("sheet:" + tmpSheet.Name);
				}


				// Create folder in home
				Folder folder = new Folder.CreateFolderBuilder("New Folder").Build();
				folder = smartsheet.HomeResources.FolderResources.CreateFolder(folder);
				Console.WriteLine("Folder ID:" + folder.Id + ", Folder Name:" + folder.Name);
				//=========================================
			}

			// Setup text Column Object
			Column textColumn = new Column.CreateSheetColumnBuilder("To Do List", true, ColumnType.TEXT_NUMBER).Build();

			// Setup checkbox Column Object
			Column checkboxColumn = new Column.CreateSheetColumnBuilder("Finished", false, ColumnType.CHECKBOX).Build();

			// Add the 2 Columns (flag & text) to a new Sheet Object
			Sheet sheet = new Sheet.CreateSheetBuilder("New Sheet", new Column[] { textColumn, checkboxColumn }).Build();
			// Send the request to create the sheet @ Smartsheet
			sheet = smartsheet.SheetResources.CreateSheet(sheet);
			//=========================================
			// Example: Add two rows
			Func<string, Row> addRowHelper = primaryColVal =>
			{
				var cells = new Cell[] { new Cell.AddCellBuilder(sheet.GetColumnByIndex(0).Id, primaryColVal).Build() };
				var rows = new Row[] { new Row.AddRowBuilder(true, null, null, null, null).SetCells(cells).Build() };
				return smartsheet.SheetResources.RowResources.AddRows(sheet.Id.Value, rows)[0];
			};

			var rowA = addRowHelper("a");
			var rowB = addRowHelper("b");

			// Example: Move rowB above rowA
			var updateRowRequest = new Row.UpdateRowBuilder(rowB.Id)
					.SetSiblingId(rowA.Id)
					.SetAbove(true)
					.Build();
			var updateRowResponse = smartsheet.SheetResources.RowResources.UpdateRows(sheet.Id.Value, new Row[] { updateRowRequest });

			//Indent rowA under rowB
			updateRowRequest = new Row.UpdateRowBuilder(rowA.Id)
					.SetParentId(rowB.Id)
					.Build();
			updateRowResponse = smartsheet.SheetResources.RowResources.UpdateRows(sheet.Id.Value, new Row[] { updateRowRequest });

			//=========================================
			// Example: Add two rows
			PaginatedResult<Sheet> sheetsSince = smartsheet.SheetResources.ListSheets(null, null, DateTime.UtcNow.AddDays(-5));

			PaginatedResult<Sheet> orgSheetsSince = smartsheet.UserResources.SheetResources.ListOrgSheets(null, DateTime.UtcNow.AddDays(-10));

			PaginatedResult<Report> reportsSince = smartsheet.ReportResources.ListReports(null, DateTime.UtcNow.AddDays(-5));

			PaginatedResult<Sight> sightsSince = smartsheet.SightResources.ListSights(null, DateTime.Now.AddDays(-5));

			//=========================================
			// Example: setup a webhook
			Webhook webhook = new Webhook();
			webhook.Name = "Test webhook";
			webhook.CallbackUrl = "https://someurl.com";
			webhook.Scope = "sheet";
			webhook.ScopeObjectId = 6810644029695876L;
			IList<string> events = new List<string>();
			events.Add("*.*");
			webhook.Events = events;
			webhook.Version = 1;
			webhook = smartsheet.WebhookResources.CreateWebhook(webhook);

			PaginatedResult<Webhook> webhooks = smartsheet.WebhookResources.ListWebhooks(null);

			//// Update the shared secret 
			webhook = smartsheet.WebhookResources.GetWebhook(webhooks.Data[0].Id.Value);

			Webhook update_webhook = new Webhook();
			update_webhook.Enabled = true;
			update_webhook.Id = webhooks.Data[0].Id;
			update_webhook = smartsheet.WebhookResources.UpdateWebhook(update_webhook);

			WebhookSharedSecret shared = smartsheet.WebhookResources.ResetSharedSecret(update_webhook.Id.Value);

			smartsheet.WebhookResources.DeleteWebhook(update_webhook.Id.Value);

			//=========================================
			// Example: sights example
			PaginatedResult<Sight> sights = smartsheet.SightResources.ListSights(null);

			if (sights.TotalCount > 0)
			{
				Sight sight = smartsheet.SightResources.GetSight(sights.Data[0].Id.Value);

				ContainerDestination dest = new ContainerDestination();
				dest.DestinationType = DestinationType.FOLDER;
				dest.DestinationId = 3167806247200644L;
				dest.NewName = "My New Sight";

				sight = smartsheet.SightResources.CopySight(sights.Data[0].Id.Value, dest);

				Sight newsight = new Sight();
				newsight.Id = sight.Id;
				newsight.Name = "My New New Sight";
				smartsheet.SightResources.UpdateSight(newsight);

				ContainerDestination destToo = new ContainerDestination();
				destToo.DestinationType = DestinationType.FOLDER;
				destToo.DestinationId = 3110683182163844L;
				sight = smartsheet.SightResources.MoveSight(sight.Id.Value, destToo);

				smartsheet.SightResources.DeleteSight(sight.Id.Value);

				PaginatedResult<Share> sightShares = smartsheet.SightResources.ShareResources.ListShares(sights.Data[0].Id.Value, null, ShareScope.Workspace);
			}

			//=========================================
			// Example: cell images and partial success
			Sheet imageSheet = smartsheet.SheetResources.GetSheet(6810644029695876L, null, null, null, null, null, null, null);

			Cell[] cellsA = new Cell[] { new Cell.AddCellBuilder(imageSheet.Columns[0].Id.Value, true).Build(), new Cell.AddCellBuilder(imageSheet.Columns[1].Id.Value, "Foobar").Build() };
			rowA = new Row.AddRowBuilder(true, null, null, null, null).SetCells(cellsA).Build();

			Cell[] cellsB = new Cell[] { new Cell.AddCellBuilder(imageSheet.Columns[1].Id.Value, true).Build(), new Cell.AddCellBuilder(imageSheet.Columns[1].Id.Value, "Barfoo").Build() };
			rowB = new Row.AddRowBuilder(true, null, null, null, null).SetCells(cellsB).Build();

			BulkItemRowResult bulkAddResult = smartsheet.SheetResources.RowResources.AddRowsAllowPartialSuccess(6810644029695876L, new Row[] { rowA, rowB });

			Cell[] cellsC = new Cell[] { new Cell.AddCellBuilder(imageSheet.Columns[0].Id.Value, true).Build(), new Cell.AddCellBuilder(imageSheet.Columns[1].Id.Value, "FoobarII").Build() };
			Row rowC = new Row.UpdateRowBuilder(imageSheet.Rows[2].Id.Value).SetCells(cellsC).Build();

			Cell[] cellsD = new Cell[] { new Cell.AddCellBuilder(imageSheet.Columns[1].Id.Value, true).Build(), new Cell.AddCellBuilder(imageSheet.Columns[1].Id.Value, "BarfooII").Build() };
			Row rowD = new Row.UpdateRowBuilder(imageSheet.Rows[1].Id.Value).SetCells(cellsD).Build();

			BulkItemRowResult bulkUpdateResult = smartsheet.SheetResources.RowResources.UpdateRowsAllowPartialSuccess(6810644029695876L, new Row[] { rowC, rowD });

			ImageUrl imageUrl = new ImageUrl.ImageUrlBuilder("aVbWbXMsD5KsOu2 - CWtwSA").Build();
			IList<ImageUrl> imageUrls = new List<ImageUrl>();
			imageUrls.Add(imageUrl);

			ImageUrlMap imageUrlMap = smartsheet.ImageUrlResources.GetImageUrls(imageUrls);

			smartsheet.SheetResources.RowResources.CellResources.AddImageToCell(6810644029695876L, imageSheet.Rows[0].Id.Value, imageSheet.Columns[1].Id.Value,
				"d:\\Smartsheet\\vHepGiJaeL6GPOX3wAx8yaxD75ym5eAbk0GB-MSz0gc.png", "image/png");

			//=========================================
			//// Update two cells on a row
			//IList<Cell> cells = new Cell.UpdateRowCellsBuilder().AddCell(5111621270955908L, "test11", false).
			//		AddCell(2859821457270660L, "test22").Build();
			//smartsheet.Rows().UpdateCells(6497447011739524L, cells);
			////=========================================

			//// Create a row and sheet level discussion with an initial comment
			//Comment comment = new Comment.AddCommentBuilder().SetText("Hello World").Build();
			//Discussion discussion = new Discussion.CreateDiscussionBuilder().SetTitle("New Discussion").
			//	SetComment(comment).Build();
			//smartsheet.Rows().Discussions().CreateDiscussion(6497447011739524L, discussion);
			//smartsheet.Sheets().Discussions().CreateDiscussion(7370846613333892L, discussion);
			////=========================================

			//// Update a folder name
			//folder = new Folder.UpdateFolderBuilder().SetName("A Brand New New Folder").SetID(2545279862892420L).Build();
			//smartsheet.Folders().UpdateFolder(folder);
			////=========================================

			//// Create 3 users to share a sheet with
			//IList<User> users = new List<User>();
			//User user = new User();
			//user.Email = "brett@batie.com";
			//users.Add(user);

			//User user1 = new User();
			//user1.Email = "bbatie@gmail.com";
			//users.Add(user1);

			//User user2 = new User();
			//user2.Email = "brett.batie@smartsheet.com";
			//users.Add(user2);

			//// Add the message, subject & users to share with
			//MultiShare multiShare = new MultiShare.ShareToManyBuilder().SetMessage("Here is the sheet I am sharing with you").
			//	SetAccessLevel(AccessLevel.VIEWER).SetSubject("Sharing a Smartsheet with you").SetUsers(users).Build();

			//// Share the specified sheet with the users.
			//smartsheet.Sheets().Shares().ShareTo(7370846613333892L, multiShare, true);
			////=========================================

			//// Create a single share to a specified email address with the specified access level
			//Share share = new Share.ShareToOneBuilder().SetEmail("bbatie+12@gmail.com").SetAccessLevel(AccessLevel.VIEWER)
			//		.Build();
			//// Add the share to a specific sheet
			//smartsheet.Sheets().Shares().ShareTo(7370846613333892L, share);
			////=========================================

			//// Create a share with the specified access level
			//share = new Share.UpdateShareBuilder().SetAccessLevel(AccessLevel.VIEWER).Build();
			//// Update the share permission on the specified sheet for the specified user.
			//smartsheet.Sheets().Shares().UpdateShare(7370846613333892L, 3433212006426500L, share);
			////=========================================


			//// Create 3 cells
			//Cell cell = new Cell();
			//cell.Value = "Cell1";
			//cell.Strict = false;
			//cell.ColumnId = 5111621270955908L;
			//Cell cell2 = new Cell();
			//cell2.Value = "Cell2";
			//cell2.ColumnId = 2859821457270660L;
			//Cell cell3 = new Cell();
			//cell3.Value = "cell3";
			//cell3.ColumnId = 7877251644581764L;

			//// Store the cells in a list
			//List<Cell> cells1 = new List<Cell>();
			//cells1.Add(cell);
			//cells1.Add(cell2);
			//cells1.Add(cell3);

			//// Create a row and add the list of cells to the row
			//Row row = new Row();
			//row.Cells = cells1;

			//// Add two rows to a list of rows.
			//List<Row> rows = new List<Row>();
			//rows.Add(row);
			//rows.Add(row);

			//// Add the rows to the row wrapper and set the location to insert the rows
			//RowWrapper rowWrapper = new RowWrapper.InsertRowsBuilder().SetRows(rows).SetToBottom(true).Build();


			//// Add the rows to the specified sheet
			//smartsheet.Sheets().Rows().InsertRows(7370846613333892L, rowWrapper);


			//// Setup a row to be moved to the top of a sheet
			//RowWrapper rowWrapper1 = new RowWrapper.MoveRowBuilder().SetToTop(true).Build();
			//// Move the specified row
			//smartsheet.Rows().MoveRow(5701744190613380L, rowWrapper1);
			////=========================================


			//// Create a sheet that is a copy of a template
			//Sheet sheet1 = new Sheet.CreateFromTemplateOrSheetBuilder().SetFromId(7370846613333892L).
			//	SetName("Copy of a Template").Build();
			//// Create the new sheet from the template
			//smartsheet.Sheets().CreateSheetFromExisting(sheet1, new ObjectInclusion[] { ObjectInclusion.DATA, 
			//	ObjectInclusion.ATTACHMENTS, ObjectInclusion.DISCUSSIONS });
			////=========================================


			//// Setup a sheet with a new name
			//Sheet sheet2 = new Sheet.UpdateSheetBuilder().SetName("TESTING123").SetID(7370846613333892L).Build();

			//// Update the sheet with the new name
			//smartsheet.Sheets().UpdateSheet(sheet2);
			////=========================================


			//// Setup a publishing status to give a rich version of the sheet as read only 
			//SheetPublish publish = new SheetPublish.PublishStatusBuilder().SetReadOnlyFullEnabled(true).
			//	SetReadOnlyLiteEnabled(false).SetIcalEnabled(false).SetReadWriteEnabled(false).Build();
			//// Setup the specified sheet with the new publishing status
			//smartsheet.Sheets().UpdatePublishStatus(7370846613333892L, publish);
			////=========================================


			//// Setup a user with an email address and full permission
			//User user3 = new User.AddUserBuilder().SetEmail("newUser@batie.com").SetAdmin(true).
			//		SetLicensedSheetCreator(true).Build();
			//// Create the user account
			//smartsheet.Users().AddUser(user3);
			////=========================================


			//// Setup a user with new privileges
			//User user4 = new User.UpdateUserBuilder().SetAdmin(false).SetLicensedSheetCreator(false).
			//	SetID(4187958019417988L).Build();
			//// Send the request to update the users account with the new privileges 
			//smartsheet.Users().UpdateUser(user4);
			////=========================================


			//// Create a workspace with a specific name and ID
			//Workspace workspace = new Workspace.UpdateWorkspaceBuilder().SetName("Workspace Name1").
			//	SetID(8257948486002564L).Build();
			//// Update the workspace with the new name.
			//smartsheet.Workspaces().UpdateWorkspace(workspace);
			////=========================================

			//smartsheet.Sheets().Attachments().AttachFile(4844590336370564L,
			//	@"../../../TestSDK/resources/getPDF.pdf", "application/pdf");

			//Attachment attach = new Attachment();
			//attach.Name = "Test";
			//attach.Url = "http://google.com";
			//attach.AttachmentType = AttachmentType.LINK;
			//smartsheet.Sheets().Attachments().AttachURL(4844590336370564L, attach);
		}
	}
}