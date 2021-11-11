using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkSprayqa.Helper
{
    class ObjectIdentifiers
    {
        public static readonly string _createnewmodeltitle = "//*[@id='root']/div/div/main/div[2]/div/div[2]/div/h2";
        public static readonly string _adhesiveDropdown = "//*[@id='select-newmodel_adhesive_type_select']";
        public static readonly string _pstt = "//*[@id='menu-newmodel_adhesive_type_select']/div[2]/ul/li[1]";
        public static readonly string _psdct = "//*[@id='menu-newmodel_adhesive_type_select']/div[2]/ul/li[2]";
        public static readonly string _vha = "//*[@id='menu-newmodel_adhesive_type_select']/div[2]/ul/li[3]";
        public static readonly string _oca = "//*[@id='menu-newmodel_adhesive_type_select']/div[2]/ul/li[4]";
        public static readonly string _dropDmaFilesIdentifier = "//span[text()='Drop DMA Files']";
        public static readonly string _dropDmaFilesIdentifierwithc = "//div[@id='dmaDrop']";
        public static readonly string _dropCompFilesIdentifier = "//span[text()='Drop Compression Files']";
        public static readonly string _dropTensFilesIdentifier = "//span[text()='Drop Tension Files']";
        public static readonly string _removeFileButton = "//*[@id='dmaDrop']/div[2]/a";
        public static readonly string _cancelUploadButton = "//*[@id='root']/div/div/main/div[2]/div/div[2]/div/div/div[2]/div[1]/div/div/div[2]/a";
        public static readonly string _fileDisplayTable = "/html/body/div[3]/div/div/main/div[2]/div/div[2]/div/div/div[4]/div/div/div/div[3]/table/tbody/tr";
        public static readonly string _clearAllFilesButton = "//*[@id='root']/div/div/main/div[2]/div/div[2]/div/div/div[3]/span/span[1]";
        public static readonly string _generateConstitutiveModelBtn = "//span[text()='Generate Constitutive Mechanical Model']";
        public static readonly string _deformationModeDropdownBtn = "//*[@id='select-deformation_mode_select']";
        public static readonly string _density = "//*[@id='standard-number']";
        public static readonly string _replicateNumberDropdownBtn = "//*[@id='select-replicate_group_select']";
        public static readonly string _phase1 = "//*[@id='menu-newmodel_phase_select']/div[2]/ul/li[1]";
        public static readonly string _phase2 = "//*[@id='menu-newmodel_phase_select']/div[2]/ul/li[2]";
        public static readonly string _phase3 = "//*[@id='menu-newmodel_phase_select']/div[2]/ul/li[3]";
        public static readonly string _modelPhaseDropdown = "//*[@id='select-newmodel_phase_select']";
        public static readonly string _divisionDropdown = "//*[@id='select-newmodel_division_type_select']";
        public static readonly string _aasd = "//*[@id='menu-newmodel_division_type_select']/div[2]/ul/li[1]";
        public static readonly string _crl = "//*[@id='menu-newmodel_division_type_select']/div[2]/ul/li[2]";
        public static readonly string _dmsd = "//*[@id='menu-newmodel_division_type_select']/div[2]/ul/li[3]";
        public static readonly string _emsd = "//*[@id='menu-newmodel_division_type_select']/div[2]/ul/li[4]";
        public static readonly string _iatd = "//*[@id='menu-newmodel_division_type_select']/div[2]/ul/li[5]";
        public static readonly string _other = "//*[@id='menu-newmodel_division_type_select']/div[2]/ul/li[6]";
        public static readonly string _deformModeVal1 = "//div[@id='menu-deformation_mode_select']/div[2]/ul/li[1]";
        public static readonly string _deformModeVal2 = "//div[@id='menu-deformation_mode_select']/div[2]/ul/li[2]";
        public static readonly string _deformModeVal3 = "//div[@id='menu-deformation_mode_select']/div[2]/ul/li[3]";
        public static readonly string _deformModeVal4 = "//div[@id='menu-deformation_mode_select']/div[2]/ul/li[4]";
        public static readonly string _deformModeVal5 = "//div[@id='menu-deformation_mode_select']/div[2]/ul/li[5]";
        public static readonly string _username = "//*[@id='i0116']";
        public static readonly string _next = "//input[@type='submit']";
        public static readonly string _workac = "//div[@id='aadTileTitle']";
        public static readonly string _modelname = "//textarea[@id='model-name']";

        ///Visualize Model Data  
        public static readonly string _selectorModeIdentifier = "//*[@id='select-viz_model_select']";
        public static readonly string _chartTypeDropdown = "//*[@id='select-viz_chart_select']";
        public static readonly string _chartTypeVal1 = "//*[@id='menu-viz_chart_select']/div[2]/ul/li[1]";
        public static readonly string _chartTypeVal2 = "//*[@id='menu-viz_chart_select']/div[2]/ul/li[2]";
        public static readonly string _chartTypeVal3 = "//*[@id='menu-viz_chart_select']/div[2]/ul/li[3]";
        public static readonly string _chartTypeVal4 = "//*[@id='menu-viz_chart_select']/div[2]/ul/li[4]";
        public static readonly string _chartTypeVal5 = "//*[@id='menu-viz_chart_select']/div[2]/ul/li[5]";
        public static readonly string _chartTypeVal6 = "//*[@id='menu-viz_chart_select']/div[2]/ul/li[6]";
        public static readonly string _chartTypeVal7 = "//*[@id='menu-viz_chart_select']/div[2]/ul/li[7]";
        public static readonly string _mastercurvereftemp = "//input[@type='number' and @id='masterCurveRefTempSelect']";
        public static readonly string _disableupdatemastercurve = "//*[@id='viz']/div/div/div[2]";
        public static readonly string _curvetodisplay = "//*[@id='viz']/div/div/div[2]/div[3]/span";
        public static readonly string _updatemastercurve = "//*[@id='viz']/div/div/div[2]/span[1]/span[1]";
        public static readonly string _saveChartBtn = "//span[text()='Save Chart as PNG']";
        public static readonly string _visulizeModelTitle = "//*[@id='viz']/h2";

        //Export and save models

        public static readonly string _modelNameSelectButton = "//*[@id='export']/div/div/div[1]/div/div[3]/table/thead/tr/th[1]/span/span[1]/input";
        public static readonly string _saveSelectedModelsButton = "//span[text()='Save Selected Models']";
        public static readonly string _modelSavedTickIdentifier = "/html/body/div[3]/div/div/main/div[6]/div/div/div[2]/div/div/div[1]/div/div[3]/table/tbody/tr/td[11]";
        public static readonly string _tick = "svg[role='presentation'][style='fill: green;'][class='jss1710']";
        public static readonly string _tick1 = "svg[role='presentation'][style='fill: crimson;'][class='jss1710']";
        public static readonly string _fileUploadTableIdentifier = "/html/body/div[3]/div/div/main/div[2]/div/div[2]/div/div/div[4]/div/div/div/div[3]/table";
        public static readonly string _dmaUploadSecondFile = "/html/body/div[3]/div/div/main/div[2]/div/div[2]/div/div/div[4]/div/div/div/div[3]/table/tbody/tr[2]/td[2]";
        public static readonly string _exportModelasZipButton = "//span[text()='Export External Data Package (*.zip)']";

        //Load Your Models
        public static readonly string _loadYourModelsIdentifier = "//*[@id='root']/div/div/div/div/div/div/div[2]/nav[1]/li[2]/div[2]/p";
        public static readonly string _modelSearchboxButton = "//*[@id='root']/div/div/main/div[3]/div/div/div/div[2]/div[1]/div/div/div[1]/div[2]/button/span[1]/svg";
        public static readonly string _modelSearchboxIdentifier = "/html/body/div[3]/div/div/main/div[3]/div/div/div/div[2]/div[1]/div/div/div[1]/div[1]/div/div/div/input";
        public static readonly string _modelNameIdentifier = "//*[@id='root']/div/div/main/div[3]/div/div/div/div[2]/div[1]/div/div/div[1]/div[1]/div/div/div/input";
        public static readonly string _modelNameCheckboxIdentifier = "//*[@id='root']/div/div/main/div[3]/div/div/div/div[2]/div[1]/div/div/div[3]/table/tbody/tr[3]/td[1]/span/span[1]/input";
        public static readonly string _modelNameTextBox = "//*[@id='root']/div/div/main/div[3]/div/div/div/div[2]/div[1]/div/div/div[3]/table/tbody/tr[3]/td[3]";
        public static readonly string _loadConstitutiveModelButton = "/html/body/div[3]/div/div/main/div[3]/div/div/div/div[2]/div[2]/div/span/span[1]";
        public static readonly string _visualizeModelDataButton = "/html/body/div[3]/div/div/div/div/div/div/div[2]/nav[2]/li[1]/div/p";
        //public static readonly string _visualizeModelCss = "//*[@id='viz']/h2";

        //edit your models  
        public static readonly string _editexistingmodeltitle = "//*[@id='root']/div/div/main/div[4]/div/div/div/h2";
        public static readonly string _editYourModelsIdentifier = "//*[@id='root']/div/div/div/div/div/div/div[2]/nav[1]/li[3]/div[2]/p";
        public static readonly string _searchboxEditModelButton = "//button[@class='jss1178 jss1172 jss1156' and @title='Search']";
        public static readonly string _searchBoxInputIdentifier = "//input[@class='jss1279 jss2216' and @type='text']";
        public static readonly string _checkboxEditModel = "/html/body/div[3]/div/div/main/div[4]/div/div/div/div/div[1]/div/div/div[3]/table/tbody/tr[1]/td[1]/span/span[1]/input";
        public static readonly string _deleteSelectedModelBtn = "//*[@id='root']/div/div/main/div[4]/div/div/div/div/div[2]/div/span[2]/span[1]";
        public static readonly string _deleteConfirmBtn = "/html/body/div[5]/div[2]/div/div[3]/button[2]/span[1]";
        public static readonly string _canceldeleteConfirmBtn = "/html/body/div[5]/div[2]/div/div[3]/button[1]/span[1]";
        public static readonly string _modelEditCheckboxBtn = "//*[@id='root']/div/div/main/div[4]/div/div/div/div/div[1]/div/div/div[3]/table/tbody/tr[1]/td[1]/span/span[1]/input";
        public static readonly string _descrptionTextboxIdentifier = "//*[@id='edit_0_descinput']";
        public static readonly string _updateSelectedModelBtn = "//*[@id='root']/div/div/main/div[4]/div/div/div/div/div[2]/div/span[1]/span[1]";

        //Verified Models
        public static readonly string _verifiedModelsBtn = "//*[@id='root']/div/div/div/div/div/div/div[2]/nav[2]/li[3]/div[2]/p";
        public static readonly string _searchBoxIdentifier = "//*[@id='root']/div/div/main/div[7]/div/div/div/div[2]/div/div/div/div[1]/div[2]/button/span[1]/svg";
        public static readonly string _searchBoxVerifiedModels = "//*[@id='root']/div/div/main/div[7]/div/div/div/div[2]/div/div/div/div[1]/div[1]/div/div/div/input";
        public static readonly string _verifiedModelsTableIdentifier = "//*[@id='root']/div/div/main/div[7]/div/div/div/div[2]/div/div/div/div[3]/table/tbody/tr/td[2]";
        public static readonly string _downloadModelInternal = "//*[@id='root']/div/div/main/div[7]/div/div/div/div[2]/div/div/div/div[3]/table/tbody/tr/td[14]/span/span/u";
        public static readonly string _downloadModelExternal = "//*[@id='root']/div/div/main/div[7]/div/div/div/div[2]/div/div/div/div[3]/table/tbody/tr/td[16]/span/span/u";
    }
}
