using System;
using System.Threading.Tasks;
using Vculp.Api.Common.Common;

namespace Vculp.Api.Application.Services.Interfaces.Reporting.Services
{
    public interface IReportingService
    {
        /// <summary>
        /// Get vwd report document.
        /// </summary>
        /// <param name="vwdId"> Vwd id. </param>
        /// <returns> Vwd report document content </returns>
        Task<OperationResult<PdfDocument>> GetVwdReportDocumentAsync(Guid vwdId);

        /// <summary>
        /// Get order document.
        /// </summary>
        /// <param name="orderId"> Order id. </param>
        /// <returns> order summery document content </returns>
        Task<OperationResult<PdfDocument>> GetOrderDetailsReportAsync(Guid orderId);

        /// <summary>
        /// Get RawMaterial Docket.
        /// </summary>
        /// <param name="docketId"> DocketId. </param>
        Task<OperationResult<PdfDocument>> GetRawMaterialDocketAsync(Guid docketId);

        /// <summary>
        /// Get Collection Order.
        /// </summary>
        /// <param name="collectionOrderId"> CollectionOrderId. </param>
        Task<OperationResult<PdfDocument>> GetCollectionOrderAsync(Guid collectionOrderId);

        /// <summary>
        /// Get Docket In.
        /// </summary>
        /// <param name="docketId"> docketId. </param>
        Task<OperationResult<PdfDocument>> GetDocketInAsync(Guid docketId);

        /// <summary>
        /// Get Docket Out.
        /// </summary>
        /// <param name="docketId"> docketId. </param>
        Task<OperationResult<PdfDocument>> GetDocketOutAsync(Guid docketId);

        /// <summary>
        /// Gets pig template label report.
        /// </summary>
        /// <param name="millCode"> Mill code </param>
        /// <param name="productCode"> Product code </param>
        /// <param name="medicationCode"> Medication code </param>
        /// <param name="runNumber"> Run number </param>
        /// <returns> Pig template label report content. </returns>
        Task<OperationResult<PdfDocument>> GetPigTemplateLabelReportAsync(string millCode, string productCode, string medicationCode, string runNumber);

        /// <summary>
        /// Gets ruminant template label report.
        /// </summary>
        /// <param name="millCode"> Mill code </param>
        /// <param name="productCode"> Product code </param>
        /// <param name="runNumber"> Run number </param>
        /// <param name="manufactureDate"> Manufacture date </param>
        /// <returns> Ruminant template label report content. </returns>
        Task<OperationResult<PdfDocument>> GetRuminantTemplateLabelReportAsync(string millCode, string productCode, string runNumber, DateTime manufactureDate);

    }
}