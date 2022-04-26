using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArt.API.ViewModels
{
    public class HeaderUserInfoViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Alias { get; set; }
        public int PaintingsCount { get; set; }
        public int PhotosCount { get; set; }
        public int SculpturesCount { get; set; }
    }
}
