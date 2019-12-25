namespace Orneholm.SverigesRadio.Api.Models.Request.Programs
{
    public class ProgramListRequest : ListRequestBase
    {
        /// <summary>
        /// Filtrera resultatet. Använd <see cref="ProgramListHasOnDemandFilter"/>, <see cref="ProgramListHasPodFilter"/>, <see cref="ProgramListArchiveFilter"/> eller <see cref="ProgramListResponsibleEditorFilter"/>.
        /// </summary>
        public ProgramListFilter? Filter { get; set; } = null;

        /// <summary>
        /// Listar program endast för angiven kanal.
        /// </summary>
        public int? ChannelId { get; set; }

        /// <summary>
        /// Lista program endast för angiven kategori.
        /// </summary>
        public int? ProgramCategoryId { get; set; }

        /// <summary>
        /// Styr om listan ska innehålla enbart aktiva (false) eller arkiverade (true) program.
        /// Default listas samtliga program.
        /// </summary>
        public bool? IsArchived { get; set; }
    }
}
