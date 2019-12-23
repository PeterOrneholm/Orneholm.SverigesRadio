namespace Orneholm.SverigesRadio.Api.Models.Response.Programs
{
    public class Program
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ProgramCategory ProgramCategory { get; set; } = new ProgramCategory();
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string ProgramUrl { get; set; } = string.Empty;
        public string ProgramSlug { get; set; } = string.Empty;
        public string ProgramImage { get; set; } = string.Empty;
        public string ProgramImageTemplate { get; set; } = string.Empty;
        public string ProgramImageWide { get; set; } = string.Empty;
        public string ProgramImageTemplateWide { get; set; } = string.Empty;
        public string SocialImage { get; set; } = string.Empty;
        public string SocialImageTemplate { get; set; } = string.Empty;
        public ProgramSocialMediaPlatform[] SocialMediaPlatforms { get; set; } = {};
        public ProgramChannel Channel { get; set; } = new ProgramChannel();
        public bool Archived { get; set; }
        public bool HasOnDemand { get; set; }
        public bool HasPod { get; set; }
        public string ResponsibleEditor { get; set; } = string.Empty;

        public override string ToString() => $"Program: {Name} ({Id})";
    }
}
