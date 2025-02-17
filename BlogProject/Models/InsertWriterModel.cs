namespace BlogProject.Models
{
	public class InsertWriterModel
	{
		public int WriterID { get; set; }
		public string? WriterName { get; set; } // ? işareti boş geçilebilir yapıyor
		public string? WriterAbout { get; set; } // About Hakkında
		public IFormFile WriterImage { get; set; } // Dosya türünden ekleyebilmek için.
		public string? WriterMail { get; set; }
		public string? WriterPassword { get; set; }
		public bool WriterStatus { get; set; }
	}
}
