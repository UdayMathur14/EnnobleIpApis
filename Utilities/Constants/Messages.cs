namespace Utilities.Constants
{
    public static class Messages
    {
        private static readonly Dictionary<string, ErrorDetail> ValidationErrors = CreateDictionary();


        #region Common
        public static ErrorDetail EntityNotFound => new ErrorDetail(Codes.EntityNotFound, Category.Error, Descriptions.EntityNotFound, "entity");
        public static ErrorDetail InvalidCount
        {
            get
            {
                return new(Codes.InvalidCount, Category.Warning, Descriptions.InvalidCount, "count");
            }
        }
        public static ErrorDetail InvalidOffset
        {
            get
            {
                return new(Codes.InvalidOffset, Category.Warning, Descriptions.InvalidOffset, "offset");
            }
        }
        public static ErrorDetail AlreadyExists
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.AlreadyExists, "entity");
            }
        }
        public static ErrorDetail InvalidNumber
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidNumber, "");
            }
        }
        public static ErrorDetail InvalidContactNo
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidContactNo, "");
            }
        }
        public static ErrorDetail InvalidEmailId
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidEmailId, "");
            }
        }
        public static ErrorDetail InvalidStatus
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidStatus, "Status");
            }
        }
        public static ErrorDetail GetErrorDetail(string code, string description, string element, Category category = Category.Error)
        {
            return new ErrorDetail(code, category, description, element);
        }
        public static bool TryGetValidationErrorDetail(string code, out ErrorDetail value)
        {
            return ValidationErrors.TryGetValue(code, out value);
        }
        private static Dictionary<string, ErrorDetail> CreateDictionary()
        {
            var dictionary = new Dictionary<string, ErrorDetail>()
            {

            };
            return dictionary;
        }

        #endregion

        #region Courier Master
        public static ErrorDetail InvalidPlant
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidPlant, "");
            }
        }
        public static ErrorDetail InvalidBankMode
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidBankMode, "");
            }
        }
        public static ErrorDetail InvalidBank
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidBank, "");
            }
        }
        public static ErrorDetail InvalidSource
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidSource, "");
            }
        }
        public static ErrorDetail InvalidDestination
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidDestination, "");
            }
        }
        public static ErrorDetail InvalidUnitFare
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidUnitFare, "");
            }
        }
        public static ErrorDetail InvalidMinBasicFreightId
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidMinBasicFreightId, "");
            }
        }
        public static ErrorDetail InvalidMinBasicFreightCharge
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidMinBasicFreightCharge, "");
            }
        }
        public static ErrorDetail InvalidMinTerminalHandlingCharge
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidMinTerminalHandlingCharge, "");
            }
        }
        public static ErrorDetail InvalidDocketCharge
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidDocketCharge, "");
            }
        }
        public static ErrorDetail InvalidOda
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidOda, "");
            }
        }
        public static ErrorDetail InvalidNFormCharge
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidNFormCharge, "");
            }
        }
        public static ErrorDetail InvalidStateCharge
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidStateCharge, "");
            }
        }
        public static ErrorDetail InvalidFuelSurCharge
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidFuelSurCharge, "");
            }
        }
        public static ErrorDetail InvalidGreenTax
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidGreenTax, "");
            }
        }
        public static ErrorDetail InvalidFreightCharge
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidFreightCharge, "");
            }
        }
        public static ErrorDetail InvalidVehicleSize
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidVehicleSize, "");
            }
        }
        public static ErrorDetail InvalidHandlingAmount
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidHandlingAmount, "");
            }
        }
        public static ErrorDetail InvalidPoint
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidPoint, "");
            }
        }
        public static ErrorDetail InValidFreightCode => new ErrorDetail(Codes.InvalidFreightCode, Category.Error, Descriptions.ErrorInFreightCode, "freightcode");

        #endregion

        #region Lookup Master
        public static ErrorDetail InvalidTypeId
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidTypeId, "");
            }
        }
        public static ErrorDetail InvalidCode
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidCode, "");
            }
        }
        public static ErrorDetail InvalidValue
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidValue, "");
            }
        }
        public static ErrorDetail InvalidDescription
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidDescription, "");
            }
        }
        #endregion

        #region Plant Master
        public static ErrorDetail InvalidWarehouseType
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidWarehouseType, "");
            }
        }

        public static ErrorDetail InvalidProfitCenter
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidProfitCenter, "");
            }
        }

        public static ErrorDetail InvalidCostCenter
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidCostCenter, "");
            }
        }

        public static ErrorDetail InvalidSectionCode
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidSectionCode, "");
            }
        }

        public static ErrorDetail InvalidBusinessPlace
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidBusinessPlace, "");
            }
        }

        #endregion

        #region Transaction Type Master
        public static ErrorDetail InvalidCountry
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidCountry, "");
            }
        }
        public static ErrorDetail InvalidGLSubCategory
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidGLSubCategory, "");
            }
        }

        #endregion

        #region Bank Master
        public static ErrorDetail InvalidTaxationType
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidTaxationType, "");
            }
        }

        public static ErrorDetail InvalidPlantName
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidPlantName, "");
            }
        }

        public static ErrorDetail InvalidTransportationMode
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidTransportationMode, "");
            }
        }

        public static ErrorDetail InvalidTaxCode
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidTaxCode, "");
            }
        }

        public static ErrorDetail InvalidTdsCode
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidTdsCode, "");
            }
        }

        #endregion

        #region MND Upload Transaction

        public static ErrorDetail ChargeableWeightFreightCode
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.ChargeableWeightFreightCode, "ErrorInFreightCode");
            }
        }

        public static ErrorDetail FrlrNumberMustbeSame
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.FrlrNumberMustbeSame, "");
            }
        }

        public static ErrorDetail FrmTransactionAgainstFrlr
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.FrmTransactionAgainstFrlr, "");
            }
        }

        public static ErrorDetail FrmTransactionAgainstComb
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.FrmTransactionAgainstComb, "");
            }
        }

        public static ErrorDetail InvalidBankDvfm
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidBankDvfm, "");
            }
        }

        public static ErrorDetail InvalidSourceDvfm
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidSourceDvfm, "");
            }
        }

        public static ErrorDetail InvalidDestinationDvfm
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidDestinationDvfm, "");
            }
        }

        public static ErrorDetail InvalidDvfm
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidDvfm, "");
            }
        }

        public static ErrorDetail InvalidCourier
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidCourier, "");
            }
        }

        public static ErrorDetail InvalidFormat
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidFormat, "");
            }
        }

        public static ErrorDetail InvalidCustomer
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidCustomer, "");
            }
        }

        #endregion

        #region Freight Calculation Transaction

        public static ErrorDetail InvalidFrlrNumber
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidFrlrNumber, "");
            }
        }

        public static ErrorDetail AlreadyFrlrNumber
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.AlreadyFrlrNumber, "");
            }
        }

        public static ErrorDetail MultipleDvfm
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.MultipleDvfm, "");
            }
        }

        public static ErrorDetail MultipleChargeableWeight
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.MultipleChargeableWeight, "");
            }
        }

        public static ErrorDetail InvalidBankinFreightCalculation
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidBankinFreightCalculation, "");
            }
        }

        #endregion

        #region Bill Validation

        public static ErrorDetail InvalidDebitCreditAmount
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidDebitCreditAmount, "");
            }
        }

        public static ErrorDetail DuplicateEntries
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.DuplicateEntries, "");
            }
        }

        public static ErrorDetail InvalidPlantBank
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidPlantBank, "");
            }
        }

        public static ErrorDetail InvalidFreightCalculation
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidFreightCalculation, "");
            }
        }

        public static ErrorDetail InvalidSendInProcess
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidSendInProcess, "");
            }
        }

        public static ErrorDetail InvalidSendApproved
        {
            get
            {
                return new(Codes.DataValidationError, Category.Error, Descriptions.InvalidSendApproved, "");
            }
        }

        #endregion

        private readonly struct Descriptions
        {
            #region Common
            public const string EntityNotFound = "Requested record was not found or inaccessible";
            public const string InvalidCount = "Invalid or missing count, using default value of 50";
            public const string InvalidOffset = "Invalid or missing count, using default value of 0";
            public const string AlreadyExists = "Entity with same details already exists";
            public const string InvalidNumber = "Please provide valid number";
            public const string InvalidContactNo = "Please provide valid contact number.";
            public const string InvalidEmailId = "Please provide valid email Id.";
            public const string InvalidStatus = "Status must be either 'Active' or 'Inactive'.";
            #endregion

            #region Courier Master
            public const string InvalidPlant = "Please provide valid plant name.";
            public const string InvalidBankMode = "Please provide valid bank mode.";
            public const string InvalidBank = "Please provide valid bank name.";
            public const string InvalidSource = "Please provide valid source name.";
            public const string InvalidDestination = "Please provide valid destination name.";
            public const string InvalidUnitFare = "Please provide unit fare.";
            public const string InvalidMinBasicFreightId = "Please provide valid minimum basic freight category.";
            public const string InvalidMinBasicFreightCharge = "Please provide valid minimum basic freight charge.";
            public const string InvalidMinTerminalHandlingCharge = "Please provide valid minimum terminal handling charge.";
            public const string InvalidDocketCharge = "Please provide valid docket charge.";
            public const string InvalidNFormCharge = "Please provide valid N-Form charge.";
            public const string InvalidStateCharge = "Please provide valid state charge.";
            public const string InvalidFuelSurCharge = "Please provide valid fuel surcharge percentage.";
            public const string InvalidGreenTax = "Please provide valid green tax.";
            public const string InvalidFreightCharge = "Please provide valid freight charge.";
            public const string InvalidHandlingAmount = "Please provide valid handling amount";
            public const string InvalidVehicleSize = "Please provide valid vehicle size.";
            public const string ErrorInFreightCode = "Error while generating freightcode.";
            public const string InvalidPoint = "Please provide valid point name.";
            public const string InvalidOda = "Please provide valid Oda charge.";
            #endregion

            #region Lookup Master
            public const string InvalidTypeId = "Please provide valid lookup type.";
            public const string InvalidCode = "Please provide valid code.";
            public const string InvalidValue = "Please provide valid value.";
            public const string InvalidDescription = "Please provide valid description.";
            #endregion

            #region Plant Master
            public const string InvalidWarehouseType = "Please provide valid warehouse type name.";
            public const string InvalidProfitCenter = "Please provide profit center name.";
            public const string InvalidCostCenter = "Please provide valid cost center name.";
            public const string InvalidSectionCode = "Please provide valid section code name.";
            public const string InvalidBusinessPlace = "Please provide valid business place name.";
            #endregion

            #region Transaction Type Master
            public const string InvalidCountry = "Please provide valid interface transaction type name.";
            public const string InvalidGLSubCategory = "Please provide valid GL sub category.";
            #endregion

            #region Bank Master
            public const string InvalidTaxationType = "Please provide valid taxation type.";
            public const string InvalidPlantName = "Please provide valid plant code.";
            public const string InvalidTransportationMode = "Please provide valid transportation mode.";
            public const string InvalidTaxCode = "Please provide valid tax code.";
            public const string InvalidTdsCode = "Please provide valid tds code.";
            #endregion

            #region MND Upload Transaction
            public const string ChargeableWeightFreightCode = "Either 'newChargeableWeight' or 'newDirectVehicleFreightCode' must be provided, but not both.";
            public const string FrlrNumberMustbeSame = "All FrlrNumbers must be the same.";
            public const string FrmTransactionAgainstFrlr = "No matching Frm Transactions found for frlr/mdn number.";
            public const string FrmTransactionAgainstComb = "No matching MDNTxnEntity found for the combination Plant,DocumentNumber,FrlrNumber,TransportName.";
            public const string InvalidBankDvfm = "Bank of directVehicleFreight does not match with Bank of FRM Txn.";
            public const string InvalidSourceDvfm = "Source of directVehicleFreight does not match FromDestination of mdnTxn.";
            public const string InvalidDestinationDvfm = "Destination and Points of directVehicleFreight does not match ToDestination of mdnTxn.";
            public const string InvalidDvfm = "No matching direct vehicle freight code.";
            public const string InvalidCourier = "No matching courier entry exist in courier master.";
            public const string InvalidFormat = "Either 'NewDirectVehicleFreightCode' or 'NewChargeableWeight' must be provided.";
            public const string InvalidCustomer = "Invalid customer code in uploaded data.";
            #endregion

            #region Freight Calculation Transaction
            public const string InvalidFrlrNumber = "Please provide valid MDN/FRLR number.";
            public const string AlreadyFrlrNumber = "A record with the same MDN/FRLR Number already exists.";
            public const string MultipleDvfm = "Multiple DirectVehicleFreight values found.";
            public const string MultipleChargeableWeight = "Multiple ChargeableWeight values found.";
            public const string InvalidBankinFreightCalculation = "Please create entry in courier master for the given bank";
            #endregion

            #region
            public const string InvalidDebitCreditAmount = "You cannot enter non-zero values for both DebitAmount and CreditAmount. Please enter only one.";
            public const string DuplicateEntries = "Duplicate entries are not allowed for MDN/FRLR Number.";
            public const string InvalidPlantBank = "Invalid Plant Code, Bank Code and Transportation Mode.";
            public const string InvalidFreightCalculation = "FreightCalculationEntity not found for MdnFrlrNumber.";
            public const string InvalidSendInProcess = "Bill Validation Entry already in process of approval";
            public const string InvalidSendApproved = "Bill Validation Entry already approved by account's";
            #endregion
        }
    }
}
