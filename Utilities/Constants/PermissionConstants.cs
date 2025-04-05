namespace Utilities.Constants
{
    public static class PermissionConstants
    {
        #region Masters

        #region Look Up Master
        public const string AddLookUpMaster = "SVC_MST_LOOKUP_MASTER_ADD";
        public const string EditLookUpMaster = "SVC_MST_LOOKUP_MASTER_EDIT";
        public const string ViewLookUpMaster = "SVC_MST_LOOKUP_MASTER_VIEW";
        #endregion

        #region Look Up Type Master
        public const string AddLookUpTypeMaster = "AllPermissions";
        public const string EditLookUpTypeMaster = "AllPermissions";
        public const string ViewLookUpTypeMaster = "AllPermissions";
        #endregion

        #region Plant Master
        public const string EditPlantMaster = "SVC_MST_PLANT_MASTER_EDIT";
        public const string ViewPlantMaster = "SVC_MST_PLANT_MASTER_VIEW";
        #endregion

        #region Transaction Type Master
        public const string EditCountryMaster = "SVC_MST_TRANSACTION_TYPE_MASTER_EDIT";
        public const string ViewCountryMaster = "SVC_MST_TRANSACTION_TYPE_MASTER_VIEW";
        #endregion

        #region Transaction Type Interface Master
        public const string ViewCountryInterfaceMaster = "AllPermissions";
        #endregion

        #region Bank Master
        public const string EditBankMaster = "SVC_MST_TRANSPORTER_MASTER_EDIT";
        public const string ViewBankMaster = "SVC_MST_TRANSPORTER_MASTER_VIEW";
        #endregion

        #region Customer Master
        public const string EditCustomerMaster = "SVC_MST_CUSTOMER_MASTER_VIEW";
        public const string ViewCustomerMaster = "SVC_MST_COURIER_MASTER_ADD";
        #endregion

        #region Courier Master
        public const string AddCourierMaster = "SVC_MST_COURIER_MASTER_ADD";
        public const string EditCourierMaster = "SVC_MST_COURIER_MASTER_EDIT";
        public const string ViewCourierMaster = "SVC_MST_COURIER_MASTER_VIEW";
        #endregion

        #region Direct Vehicle Freight Master
        public const string AddDirectVehicleFreightMaster = "SVC_MST_DIRECT_VEHICLE_FREIGHT_MASTER_ADD";
        public const string EditDirectVehicleFreightMaster = "SVC_MST_DIRECT_VEHICLE_FREIGHT_MASTER_EDIT";
        public const string ViewDirectVehicleFreightMaster = "SVC_MST_DIRECT_VEHICLE_FREIGHT_MASTER_VIEW";
        #endregion

        #endregion

        #region Transactions

        #region MDN Transaction
        public const string EditMDNTransaction = "AllPermissions";
        public const string ViewMDNTransaction = "AllPermissions";
        #endregion

        #region MDN Upload Transaction
        public const string EditMdnUploadTransaction = "SVC_TXN_MDN_DOWNLOAD_UPLOAD_EDIT";
        public const string ViewMdnUploadTransaction = "SVC_TXN_MDN_DOWNLOAD_UPLOAD_VIEW";
        #endregion

        #region Freight Calculation Transaction
        public const string EditFreightCalculation = "SVC_TXN_FREIGHT_CALCULATION_EDIT";
        public const string ViewFreightCalculation = "SVC_TXN_FREIGHT_CALCULATION_VIEW";
        public const string CreateFreightCalculation = "SVC_TXN_FREIGHT_CALCULATION_ADD";
        #endregion

        #region Bill Validation Calculation Transaction
        public const string EditBillValidation = "SVC_TXN_BILL_VALIDATION_EDIT";
        public const string ViewBillValidation = "SVC_TXN_BILL_VALIDATION_VIEW";
        public const string CreateBillValidation = "SVC_TXN_BILL_VALIDATION_ADD";
        #endregion


        #endregion

        #region Reports

        #region Error Logging Report
        public const string ViewErrorLogging = "AllPermissions";
        #endregion

        #region ViewProvisionalReport
        public const string ViewProvisionalReport = "AllPermissions";
        #endregion

        #endregion
    }

    public static class PolicyConstants
    {
        #region Masters

        #region Look Up Master
        public const string AddLookUpMasterPolicy = "AddLookUpMasterPolicy";
        public const string EditLookUpMasterPolicy = "EditLookUpMasterPolicy";
        public const string ViewLookUpMasterPolicy = "ViewLookUpMasterPolicy";
        #endregion

        #region Look Up Type Master
        public const string AddLookUpTypeMasterPolicy = "AddLookUpTypeMasterPolicy";
        public const string EditLookUpTypeMasterPolicy = "EditLookUpTypeMasterPolicy";
        public const string ViewLookUpTypeMasterPolicy = "ViewLookUpTypeMasterPolicy";
        #endregion

        #region Customer Master
        public const string EditCustomerMasterPolicy = "EditCustomerMasterPolicy";
        public const string ViewCustomerMasterPolicy = "ViewCustomerMasterPolicy";
        #endregion

        #region Plant Master
        public const string EditPlantMasterPolicy = "EditPlantMasterPolicy";
        public const string ViewPlantMasterPolicy = "ViewPlantMasterPolicy";
        #endregion

        #region Transaction Type Master
        public const string EditCountryMasterPolicy = "EditCountryMasterPolicy";
        public const string ViewCountryMasterPolicy = "ViewCountryMasterPolicy";
        #endregion

        #region Transaction Type Interface Master
        public const string ViewCountryInterfaceMasterPolicy = "ViewCountryInterfaceMasterPolicy";
        #endregion

        #region Bank Master
        public const string EditBankMasterPolicy = "EditBankMasterPolicy";
        public const string ViewBankMasterPolicy = "ViewBankMasterPolicy";
        #endregion

        #region Courier Master
        public const string AddCourierMasterPolicy = "AddCourierMasterPolicy";
        public const string EditCourierMasterPolicy = "EditCourierMasterPolicy";
        public const string ViewCourierMasterPolicy = "ViewCourierMasterPolicy";
        #endregion

        #region Direct Vehicle Freight Master
        public const string EditDirectVehicleFreightMasterPolicy = "DirectVehicleFreightMasterPolicy";
        public const string ViewDirectVehicleFreightMasterPolicy = "ViewDirectVehicleFreightMasterPolicy";
        public const string AddDirectVehicleFreightMasterPolicy = "AddDirectVehicleFreightMasterPolicy";
        #endregion

        #endregion

        #region Transactions

        #region MDN Transaction
        public const string EditMDNTransactionPolicy = "EditMDNTransactionPolicy";
        public const string ViewMDNTransactionPolicy = "ViewMDNTransactionPolicy";
        #endregion

        #region MDN Upload Transaction
        public const string EditMdnUploadTransactionPolicy = "EditMdnUploadTransactionPolicy";
        public const string ViewMdnUploadTransactionPolicy = "ViewMdnUploadTransactionPolicy";
        #endregion

        #region Freight Calculation
        public const string EditFreightCalculationPolicy = "EditFreightCalculationPolicy";
        public const string CreateFreightCalculationPolicy = "CreateFreightCalculationPolicy";
        public const string ViewFreightCalculationPolicy = "ViewFreightCalculationPolicy";
        #endregion

        #region Bill Validation Calculation
        public const string EditBillValidationPolicy = "EditBillValidationPolicy";
        public const string CreateBillValidationPolicy = "CreateBillValidationPolicy";
        public const string ViewBillValidationPolicy = "ViewBillValidationPolicy";
        #endregion


        #endregion

        #region Reports

        #region Error Logging Report
        public const string ViewErrorLoggingPolicy = "ViewErrorLoggingPolicy";
        #endregion

        #region ViewProvisionalReport
        public const string ViewProvisionalReportPolicy = "ViewProvisionalReportPolicy";
        #endregion

        #endregion
    }
}
