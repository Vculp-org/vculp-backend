using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Vculp.Api.Common.Common
{
    public class ReportSourceModel
    {
        #region Constructors

        public ReportSourceModel
        (
            string report,
            IDictionary<string, object> parameterValues
        )
        {
            if (string.IsNullOrWhiteSpace(report))
            {
                throw new ArgumentException($"{nameof(report)} is null, empty or contains only whitespace", nameof(report));
            }

            Report = report;
            ParameterValues = parameterValues;
        }

        #endregion

        #region Properties

        [JsonProperty("Report")]
        public string Report { get; private set; }

        [JsonProperty("ParameterValues")]
        public IDictionary<string, object> ParameterValues { get; private set; }

        #endregion
    }
}