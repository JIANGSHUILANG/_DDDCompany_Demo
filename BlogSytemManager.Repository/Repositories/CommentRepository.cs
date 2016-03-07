using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BolgSytemManager.Domain.Base;
using BolgSytemManager.Domain.IRepositories;
using BolgSytemManager.Domain.Model;
using System.Data.SqlClient;
using System.Data;
using BlogSytemManager.Repository.EFContext;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
namespace BlogSytemManager.Repository.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
       
    }
}
