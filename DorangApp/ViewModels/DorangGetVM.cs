using System.ComponentModel.DataAnnotations;

namespace DorangApp.ViewModels
{
	public class DorangGetVM
	{

		[Required, MaxLength(25), MinLength(3)]
		public string Title { get; set; }

		[Required, MinLength(3)]
		public string Description { get; set; }

		[Required, MinLength(3)]
		public string ImageUrl { get; set; }
		[Required, MinLength(4)]
		public string Subtitle { get; set; }
	}
}


