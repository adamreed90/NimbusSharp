using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NimbusSharp.Data
{
    public class NimbusResult
    {
        public NimbusResult(string resultData)
        {
            NimbusCode resultCode;
            var regex = new Regex("\\[\"(?<result>.*)\\\"]");
            var match = regex.Match(resultData);
            var result = match.Groups["result"].ToString();

            if (Enum.TryParse(result, true, out resultCode))
            {
                ResultCode = resultCode;
            }
            else
            {
                ResultCode = NimbusCode.Approved;
                AuthCode = result;
            }
        }

        public string AuthCode { get; set; }

        public NimbusCode ResultCode { get; set; }

    }

    public enum NimbusCode : int
    {
        Declined = 100,
        MerchantNumberRequired = 101,
        CardNumberRequired = 102,
        PurchaseTotalRequired = 103,
        EmployeeNameRequired = 104,
        EmployeeNumberRequired = 105,
        RequiresTotaltoReload = 106,
        RequiresauthNum = 107,
        AuthNumNotfound = 108,
        EmailorPhoneRequired = 109,
        FunctionRequired = 110,
        UsernameRequired = 111,
        PasswordRequired = 112,
        UserTeamRequired = 113,
        UserActivityRequired = 114,
        UserFullNameRequired = 115,
        UserEmailRequired = 116,
        UserHashRequired = 117,
        UserFlagRequired = 118,
        UserNotFound = 119,
        EftTransactionTypeRequired = 120,
        CardCannotBeVerified = 152,
        InvalidCardDataSent = 153,
        NameonCardRequired = 154,
        CardExpirationDateRequired = 155,
        CardSecurityCodeRequired = 156,
        CardZipcodeRequired = 157,
        MerchantNotFound = 199,
        Approved = 200,
        CardDoesNotExsist = 201,
        AmountisRequiredtoProcess = 202,
        EmailAlreadybeingusedbyMerchant = 295,
        PhoneAlreadybeingused = 296,
        CardAlreadyRegistered = 297,
        MerchantIsAlreadyUsingCardNumber = 298,
        MerchantLoyaltyProgramisnotactive = 299,
        Success = 300,
        Merchantisalreadyusingthatusername = 305,
        Userdatatyperequired = 306,
        UsermustberegisteredinLoyaltyProgram = 307,
        Failuretoadduser = 308,
        Oneidentifiermustbesupplied = 309,
        CardSuccessfullyVerified = 352,
        UndefinedError = 500,
        MerchantmusthaveanactiveGiftCardProgram = 501,
        GpsCoordinatesRequired = 600,
        MerchantBoarded = 650,
        TestAccountStatusRequired = 700,
        Userisnotactive = 998,
        MerchantisInactive = 999,

    }
}
