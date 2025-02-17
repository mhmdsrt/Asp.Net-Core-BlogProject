using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class FileService : IFileService
	/*
	  ".FileName" ile dosyanın adını alıyoruz. extension -> uzantı, path -> yol
		Path.GetExtension() -> Dosyanın uzantısını alır. Örneğin: ".jpg "veya ".png"

		Guid.NewGuid() -> Benzersin bir kimlik(UUID) oluşturur. Örneğin:3f1a8f5b-678c-4e0d-934a-7c72c4b8e0b6
		Guid.NewGuid() + extension  ifadesi ile oluşturduğu benzersiz kimlik ile uzantıyı birleştirir -> 3f1a8f5b-678c-4e0d-934a-7c72c4b8e0b6.jpg

		Directory.GetCurrentDirectory() -> Projenin çalıştığı dizini döndürür, Directory -> Dizin , CurrentDirectory -> Geçerli Dizin
		 "wwwroot/WriterAddedImages/" + newImageName -> Yeni resim dosyasının kaydedileceği dizini belirler
		Path.Combine() -> Güvenli bir dosya yolu oluşturur, aşağıdaki aldığı parametreler sonucu örneğin şöyle bir şey oluşturuacak : "C:\Projects\MyApp\wwwroot\WriterAddedImages\3f1a8f5b-678c-4e0d-934a-7c72c4b8e0b6.jpg" böylelikle dosyanın kaydedileceği yeri oluşturuyoruz

		new FileStream(location, FileMode.Create):
		FileStream -> Belirtilen yolda dosya akışı(stream) açar.  Dosya işlemleri için kullanılır, dosya okuma-yazma için.
		Buradaki location -> Dosyanın kaydedileceği tam yol
		Buradaki FileMode.Create -> Belirtilen konumda dosya varsa onu silip yenisini oluşturur , dosya yoksa yenisini oluşturur.



		 */
	{
		public string FileAdd(string fileName, IFormFile image) // Parametre olarak dosya adı ve Dosya türünden image diye bir değişken alıyor yani eklenecek resim.
		{
			if (image == null)
			{
				return "Dosya Seçilmedi!";
			}
			var extension = Path.GetExtension(fileName);
			var imageName = Guid.NewGuid() + extension;
			var location = Path.Combine(Directory.GetCurrentDirectory() , "wwwroot/WriterAddedImages/" + imageName); // Dosyanın kaydedileceği tam yolu oluşturur
			var stream = new FileStream(location, FileMode.Create); // Yeni bir akış oluşturur. location'daki konuma Create işlemi için yeni bir akış.
			image.CopyTo(stream); // location konumuna FileMode.Create(Dosya oluşturma) işlemi açılan akış üzerinden dosyayı kopyalar.
			return imageName; // Database'e string olarak yeni oluşturduğumuz imageName string değerini kaydediyoruz. Çünkü veri tabanına IFormFile tipinde veri ekleleyemiyoruz.
		}
	}
}
