﻿namespace EstateWebsite.ViewModel
{
    public class UpdateHomeImagesVM
    {
        public int Id { get; set; }
        public List<IFormFile>? FormFiles { get; set; }
        public IEnumerable<string>? Images { get; set; } = Enumerable.Empty<string>();
    }
}