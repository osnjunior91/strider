using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strider.Domain.Commands.Post.Commands
{
    public class CreateRepostCommand : CreatePostCommand
    {
        public Guid RepostedFromId { get; set; }
    }
}
