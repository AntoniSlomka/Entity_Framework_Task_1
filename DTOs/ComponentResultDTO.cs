namespace EFCodeFirstTask1.DTOs
{
    public class ComponentResultDTO
    {
        //Code = v.Compo.Code,
        //Name = v.Compo.Name,
        //Type = v.CompType.Name,
        //Manufacturer = v.CompManu.Abbreviation,
        //Description = v.Compo.Description,
        //Amount = v.PCComp.Amount

        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Amount { get; set; }

    }
}
