namespace Nuclep.GestaoQualidade.BlazorServer.Helpers
{
    public class EnumDescription
    {
        public Enum? Value { get; set; }
        public string? Description { get; set; }

        public override string ToString()
        {
            return $"{Value}: {Description}";
        }
    }
}
