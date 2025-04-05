namespace Utilities.Constants
{
    public static class Service
    {
        public const string ServiceName = "ServiceFreight";
        public const string ProductId = "service";
        public const string ServiceIdentifier = "01.01";

        /*Approval Levels*/
        public const string Material = "Material";
        public const string Account = "Account";

        /*MDN Upload Messages*/
        public const string NotFoundErrorMessage = "One or more banks or direct vehicle freights were not found.";
        public const string ExistErrorMessage = "An error occurred while updating chargeable weights and freight IDs.";

        /*Freight Calculation Messages*/
        public const string FreightCalErrorMessage = "One or more banks or direct vehicle freights were not found.";

        /*Bill Validation Upload Messages*/
        public const string BillValidNotFoundErrorMessage = "\"MDN/FRLR or Bank Name is not found or already exists.";

        /*Approval Options*/
        public const string Approved = "Approved";
        public const string Rejected = "Rejected";

        /*Screen Codes for Different Approval & Master*/
        public const int SCREEN_MASTER = 101;
        public const int SCREEN_APPROVAL_ACCOUNT = 102;

        /*Transaction Codes for Approval of Different Transaction */
        public const int TRANSACTION_DVFM = 201;
        public const int TRANSACTION_COURIER = 202;
        public const int TRANSACTION_BILL_VALIDATION = 203;

        public const string DataTransferForLocalInterfaceTransactionSuccess = "Local Interface data transferred successfully to Dnet.";
        public const string DataTransferForLocalInterfaceTransactionNotExist = "No data exist for transfer to Dnet.";

        #region Transaction Layer Status
        public const string UpdateFrmTransactionsUploaded = "Uploaded";
        public const string UpdateFrmTransactionsCalculated = "Calculated";
        public const string UpdateFrmTransactionsBillValidation = "Bill Validated";
        public const string UpdateFrmTransactionsInProcessBillValidation = "Approval in Progress";
        public const string UpdateFrmTransactionsServiceHeadApproved = "Approved by Service Head";
        public const string UpdateFrmTransactionsServiceHeadRejected = "Rejected by Service Head";
        public const string UpdateFrmTransactionsAccountsApproved = "Approved by Account's Head";
        public const string UpdateFrmTransactionsAccountsRejected = "Rejected by Account's Head";
        #endregion


        #region Open Flag Status
        public const string OpenFlag = "Open";
        public const string CloseFlag = "Close";
        #endregion

        #region Open Flag Status
        public const string Active = "Active";
        public const string Inactive = "Inactive";
        #endregion

        public const string PaymentMethod = "PaymentMethod";
        public const string PaymentGroup = "PaymentGroup";
    }
}
