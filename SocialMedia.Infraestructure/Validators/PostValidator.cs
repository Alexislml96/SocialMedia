using FluentValidation;
using SocialMedia.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Validators
{
    public class PostValidator : AbstractValidator<PublicacionDTO>
    {
        public PostValidator()
        {
            RuleFor(post => post.Descripcion)
                .NotNull()
                .Length(10, 50);
            
            RuleFor(post => post.Fecha)
                .NotNull()
                .LessThan(DateTime.Now);
        }
    }
}
