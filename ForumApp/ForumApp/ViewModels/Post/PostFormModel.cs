﻿using System.ComponentModel.DataAnnotations;

using static ForumApp.Common.EntityValidations.Post;

namespace ForumApp.ViewModels.Post
{
    public class PostFormModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; } = null!;


    }
}
