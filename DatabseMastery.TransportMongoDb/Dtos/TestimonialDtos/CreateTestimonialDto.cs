namespace DatabseMastery.TransportMongoDb.Dtos.TestimonialDtos
{
    public class CreateTestimonialDto
    {
     
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Imageurl { get; set; }
        public string RewiewDetail { get; set; }
        public int RewiewScore { get; set; }
        public bool Status { get; set; }
    }
}
