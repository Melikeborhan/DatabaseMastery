namespace DatabseMastery.TransportMongoDb.Dtos.HowItWorksDtos
{
    public class GetHowItWorksByIdDto
    {
        public string HowItWorksId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public string Status { get; set; }
    }
}
