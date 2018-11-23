using FarukSahin.DataAccessLayer;
using FarukSahin.MailClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FarukSahin.Service
{
    partial class Main : ServiceBase
    {
        private BLL bll = new BLL();
        private Timer taskScheduler = new Timer();
        private Model.Smtp smtp = new Model.Smtp();
        private Model.Version version = new Model.Version();
        private Smtp sender_client;
        public Main()
        {
            InitializeComponent();            
            this.OnStart(null);
            taskScheduler.Elapsed += TaskScheduler_Elapsed;
        }

        protected override void OnStart(string[] args)
        {
            Console.WriteLine("Sunucu Bilgileri Alınıyor...");
            var sw_info = bll.Server_Info().List();
            var _instance = (Model.Smtp)Activator.CreateInstance(typeof(Model.Smtp));
            var properties = smtp.GetType().GetProperties();
            foreach (var item in sw_info)
            {
                foreach (var sub_item in properties)
                {
                    if (sub_item.Name == item.key_str)
                    {
                        Console.WriteLine(String.Format("Okunan Property {0}",sub_item.Name));
                        if (sub_item.PropertyType == typeof(int))
                        {
                            sub_item.SetValue(_instance,Convert.ToInt32(item.value_str), null);
                        }
                        else
                        {
                            sub_item.SetValue(_instance, item.value_str, null);

                        }
                    }
                            

                }
            }
            smtp = _instance;
            sender_client = new Smtp(smtp.sender,smtp.password,smtp.host,smtp.port);
            var _version_instance = (Model.Version)Activator.CreateInstance(typeof(Model.Version));
            foreach (var item in sw_info)
            {
                foreach (var sub_item in version.GetType().GetProperties())
                {
                    if (sub_item.Name == item.key_str)
                        sub_item.SetValue(_version_instance, Convert.ToInt32(item.value_str), null);
                }
            }
            version = _version_instance;
            Console.WriteLine("Sunucu Bilgileri Alındı!");
            taskScheduler.Interval = TimeSpan.FromHours(version.delay).TotalMilliseconds;
            taskScheduler.Start();
        }

        private void TaskScheduler_Elapsed(object sender, ElapsedEventArgs e)
        {
            (sender as Timer).Stop();
            var receiverList = bll.Receivers().List().Select(x=>x.mail).ToList();            
            var ports = bll.Ports().List();
            string externalip = new WebClient().DownloadString("http://icanhazip.com");
            var body = "<h1>Sunucu İp Adresi:"+externalip+"</h1><table border='2' bordercolor='black'><th>Port</th><th>Açıklama</th>";            
            foreach (var item in ports)
            {
                body += String.Format("<tr><td>{0}</td><td>{1}</td></tr>",item.port,item.description);
            }
            body += "</table>";
            sender_client.AddMail("Faruk Şahin Z270 Server Bilgilendirme!", body);
            Console.WriteLine("Mailler Gönderiliyor...");
            var b = sender_client.SendAsyncRange(receiverList).Result;            
            (sender as Timer).Start();
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
