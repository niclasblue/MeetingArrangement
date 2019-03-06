using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;  //数据库组件
using Spire.Doc;     //操作Word组件
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using static System.Console;
using Spire.Doc.Documents;

namespace MeetingArrangement
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new LeadersContext())
            {
                //1. 首先从json文件中导入领导姓名和职位

                string jsonfile = @"C:\Users\blueh\source\repos\MeetingArrangement\MeetingArrangement\Leaders.json";
                string jsonString = File.ReadAllText(jsonfile);
                //将json文件中的领导数据转换为Leader对象列表
                RootObject leaders = JsonConvert.DeserializeObject<RootObject>(jsonString);//这里使用的是Newtonsoft.json中提供的方法
                //测试是否正确读到json文件，将文件内容打印在屏幕上
                foreach (Leader leader in leaders.Leaders)
                {
                    WriteLine(leader.ToString());
                //2. 将数据写入到数据库文件中(测试阶段没有对重复数据进行处理)
                    db.Leaders.Add(leader);
                }
                db.SaveChanges();

                //将数据库中的数据读取出来
                var query = (from l in db.Leaders
                            orderby l.Rank
                            select l).Distinct();

                WriteLine("领导名单如下：");

                //使用spire.doc插件生成word文档并插入内容
                //生成一个空文档
                Document document = new Document();
                //生成一节
                Section section = document.AddSection();
                //生成一段
                Paragraph paragragh = section.AddParagraph();

                foreach (var l in query)
                {
                    WriteLine(l.ToString());
                    //将数据库中读到的数据加入文档的段落中
                    paragragh.AppendText(l.ToString());
                }

                // 3. 将领导名单生成为word文档

                document.SaveToFile(@"C:\Users\blueh\source\repos\MeetingArrangement\MeetingArrangement\Leaders.docx", FileFormat.Docx);

                //查看word文档
          //      WordDocViewer("Leaders.docx");
                WriteLine("Press a key to exit...");


                ReadKey();        
             
            }
        }
    }
    public class RootObject
    {
        public List<Leader> Leaders { get; set; }
    }

}
