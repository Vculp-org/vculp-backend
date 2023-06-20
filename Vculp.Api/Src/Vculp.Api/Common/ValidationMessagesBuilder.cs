using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Localization;

namespace Vculp.Api.Common
{
    public class ValidationMessagesBuilder
    {
        private const string CollectionIsRequiredResourceKey = "CollectionIsRequired";
        private const string FieldIsRequiredResourceKey = "FieldIsRequired";
        private const string DataNotFoundResourceKey = "NotFound";
        private const string DoesNotContainResourceKey = "EntityDoesNotContain";
        private const string InvalidLengthMaxResourceKey = "InvalidLengthMax";
        private const string InvalidEmailAddressResourceKey = "InvalidEmailAddress";
        private const string InvalidPhoneNumberResourceKey = "InvalidPhoneNumber";
        private const string InvalidResourceKey = "Invalid";
        private const string NullIsRequiredResourceKey = "NullIsRequired";
        private const string RangeResourceKey = "Range";
        private const string GreaterThanOrEqualToResourceKey = "GreaterThanOrEqualTo";

        private const string InvalidObjectForSpecifiedObjectForProductKey = "InvalidObjectForSpecifiedObjectForProduct";
        private const string InvalidObjectInTheProductsModuleKey = "InvalidObjectInTheProductsModule";
        private const string UpdateCancelledObjectResourceKey = "UpdateCancelledObject";

        private readonly IStringLocalizer<ValidationMessagesBuilder> _stringLocalizer;

        public ValidationMessagesBuilder(IStringLocalizer<ValidationMessagesBuilder> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        public string CollectionRequired(string fieldKey)
        {
            return string.Format(_stringLocalizer[CollectionIsRequiredResourceKey], _stringLocalizer[fieldKey]);
        }

        internal string Range(string fieldKey, int min, int max)
        {
            return string.Format(_stringLocalizer[RangeResourceKey], _stringLocalizer[fieldKey], min, max);
        }

        public string GreaterThanOrEqualTo(string fieldKey, int value)
        {
            return string.Format(_stringLocalizer[GreaterThanOrEqualToResourceKey], _stringLocalizer[fieldKey], value);
        }

        public string Required(string fieldKey)
        {
            return string.Format(_stringLocalizer[FieldIsRequiredResourceKey], _stringLocalizer[fieldKey]);
        }

        public string Invalid(string fieldKey)
        {
            return string.Format(_stringLocalizer[InvalidResourceKey], _stringLocalizer[fieldKey]);
        }

        public string InvalidPhoneNumber()
        {
            return _stringLocalizer[InvalidPhoneNumberResourceKey];
        }

        public string InvalidEmailAddress()
        {
            return _stringLocalizer[InvalidEmailAddressResourceKey];
        }

        public string NullIsRequired(string fieldKey)
        {
            return string.Format(_stringLocalizer[NullIsRequiredResourceKey], _stringLocalizer[fieldKey]);
        }

        public string NotFound(string entityKey, params string[] fieldKeys)
        {
            if (fieldKeys == null || fieldKeys.Length == 0)
            {
                throw new ArgumentException($"{nameof(fieldKeys)} is null or empty", nameof(fieldKeys));
            }

            var formatParams = new List<string>(); ;
            formatParams.AddRange(fieldKeys.Select(key => _stringLocalizer[key].ToString()));

            return string.Format(_stringLocalizer[DataNotFoundResourceKey], _stringLocalizer[entityKey], string.Join(", ", formatParams));
        }

        public string EntityDoesNotContain(string entityKey, string subEntityKey)
        {
            return string.Format(_stringLocalizer[DoesNotContainResourceKey], _stringLocalizer[entityKey], _stringLocalizer[subEntityKey]);
        }

        internal string InvalidLength(int max)
        {
            return string.Format(_stringLocalizer[InvalidLengthMaxResourceKey], max);
        }

        public string InvalidObjectForSpecifiedObject(string invalidObjectName, string specifiedObjectName)
        {
            return string.Format(_stringLocalizer[InvalidObjectForSpecifiedObjectForProductKey], invalidObjectName, specifiedObjectName);
        }

        public string InvalidObjectInTheProductsModule(string objectName, string specifiedObjectName)
        {
            return string.Format(_stringLocalizer[InvalidObjectInTheProductsModuleKey], objectName, specifiedObjectName);
        }

        public string ObjectIsCancelled(string objectName)
        {
            return string.Format(_stringLocalizer[UpdateCancelledObjectResourceKey], objectName);
        }
    }
}
