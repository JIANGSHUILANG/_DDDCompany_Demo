using BolgSytemManager.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolgSytemManager.Domain.Model
{

    public partial class Blog : AggregateRoot
    {
        //博客ID
        //public int ID { get; set; }
        //标题
        public string Title { get; set; }
        //回复的具体内容
        public string Content { get; set; }
        //分类  
        public int BType { get; set; }
        public Nullable<DateTime> CreateTime { get; set; }
        //是否推荐  ： 0否  1是
        public int Recommend { get; set; }
        //博客图片
        public string BlogUrl { get; set; }
        //点击量
        public int Times { get; set; }
        //支持
        public int Support { get; set; }
        //反对
        public int Oppose { get; set; }
        //途径  1：微信  2：手机客户端   3：PC端
        public int Approach { get; set; }
        //排序字段
        public int Short { get; set; }
        //其它
        public string Other { get; set; }

        //public string {get;set;}
    }
}
