using ProjectMVC.Data.Models;
using ProjectMVC.Data.Repositoryes;
using ProjectMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.BLL
{
    public class PostBL
    {
        private PostRepository _postRepository;
        public PostBL(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public void CreatePost(PostViewModel postViewModel)
        {
            var post = new Post
            {
                Body = postViewModel.Body,
                PostData = postViewModel.PostData,
                Price = postViewModel.Price,
                PostType = postViewModel.PostType
            };
            _postRepository.Add(post);
        }
    }
}
