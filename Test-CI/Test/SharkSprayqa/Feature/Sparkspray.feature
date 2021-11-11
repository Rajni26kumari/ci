Feature: SharksprayAutomation
	Matching input-output files hash code
@regression
Scenario Outline: Visualize Model Data.
	Given I have navigated to Sharkspray Web Application.
	When I set <AdhesiveType> and <ModelPhase> from sheet.
	Then I compare <dma_filename>,<compression_filename> and <tension_filename> from the sheet and upload it.
	Then I select <deformation_mode> from sheet.
	And Clicked on the genrate constitutive mechanical model button.
	Then On visualize model page click on the save chart as png button.
	And Click on export and save model check-box and description.
	Then Click on the save select model button and verify it.
	And Click on the export external data package(*.ZIP) and verify if it downloaded.
	Then Extract the downloaded file.
	And Check the status of <should_build> and remove unnecessary lines from webfile and <reference_filename>.
	Then Comapre hashvalue of web-data and <reference_filename> data and store with <name> file.
	@source:Sharkspray_Testcases.xlsx:sheet1
	Examples:
	|Sno.|name|dma_filename|compression_filename|tension_filename|reps|AdhesiveType|ModelPhase|deformation_mode|should_build|reference_filename|