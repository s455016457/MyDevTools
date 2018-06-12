using MyDevTools.Plugin.EncryptionTools.Cryptos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDevTools.Plugin.EncryptionTools.Forms
{
    public partial class RSACryptoChatForm : Form
    {
        private User Alice, Bob;
        public RSACryptoChatForm()
        {
            InitializeComponent();

            Alice = new User("Alice");
            Bob = new User("Bob");

            Alice.Subscription(Bob);
            Bob.Subscription(Alice);

            Alice.onBeginUserSendMessage += new UserMessageEventHandler(p =>
            {
                SendToConsole("Alice.onBeginUserSendMessage：【{0}发送消息给{1}，内容：{2}】", p.SendUser, p.ReceiveUser, p.Message);
            });
            Alice.onBeginUserSendMessage += new UserMessageEventHandler(p =>
            {
                AddAliceChatHistory("{0}:{1}", p.SendUser, p.Message);
            });
            Alice.onEndUserSendMessage += new UserMessageEventHandler(p =>
            {
                SendToConsole("Alice.onEndUserSendMessage：【{0}发送消息给{1}，内容：{2}】", p.SendUser, p.ReceiveUser, p.Message);
            });

            Alice.onBeginUserReceiveMessage += new UserMessageEventHandler(p =>
            {
                SendToConsole("Alice.onBeginUserReceiveMessage：【{0}发送消息给{1}，内容：{2}】", p.SendUser, p.ReceiveUser, p.Message);
            });
            Alice.onEndUserReceiveMessage += new UserMessageEventHandler(p =>
            {
                SendToConsole("Alice.onEndUserReceiveMessage：【{0}发送消息给{1}，内容：{2}】", p.SendUser, p.ReceiveUser, p.Message);
            });
            Alice.onEndUserReceiveMessage += new UserMessageEventHandler(p =>
            {
                AddAliceChatHistory("{0}:{1}", p.SendUser, p.Message);
            });

            Bob.onBeginUserSendMessage += new UserMessageEventHandler(p =>
            {
                SendToConsole("Bob.onBeginUserSendMessage：【{0}发送消息给{1}，内容：{2}】", p.SendUser, p.ReceiveUser, p.Message);
            });
            Bob.onBeginUserSendMessage += new UserMessageEventHandler(p =>
            {
                AddBobChatHistory("{0}:{1}", p.SendUser, p.Message);
            });
            Bob.onEndUserSendMessage += new UserMessageEventHandler(p =>
            {
                SendToConsole("Bob.onEndUserSendMessage：【{0}发送消息给{1}，内容：{2}】", p.SendUser, p.ReceiveUser, p.Message);
            });

            Bob.onBeginUserReceiveMessage += new UserMessageEventHandler(p =>
            {
                SendToConsole("Bob.onBeginUserReceiveMessage：【{0}发送消息给{1}，内容：{2}】", p.SendUser, p.ReceiveUser, p.Message);
            });
            Bob.onEndUserReceiveMessage += new UserMessageEventHandler(p =>
            {
                SendToConsole("Bob.onEndUserReceiveMessage：【{0}发送消息给{1}，内容：{2}】", p.SendUser, p.ReceiveUser, p.Message);
            });
            Bob.onEndUserReceiveMessage += new UserMessageEventHandler(p =>
            {
                AddBobChatHistory("{0}:{1}", p.SendUser, p.Message);
            });

            AlicePublicKey.Text = Alice.PublicKey;
            BobPublicKey.Text = Bob.PublicKey;
        }

        private void AliceSend_Click(object sender, EventArgs e)
        {
            SendToConsole("===========================================Alice Send Message {0}===========================================", DateTime.Now.ToString("o"));
            Alice.SendMessage(AliceSendText.Text.Trim());
            AliceSendText.Text = String.Empty;
        }

        private void BobSend_Click(object sender, EventArgs e)
        {
            SendToConsole("===========================================Bob Send Message {0}===========================================", DateTime.Now.ToString("o"));
            Bob.SendMessage(BobSendText.Text.Trim());
            BobSendText.Text = String.Empty;
        }

        private void SendToConsole(String format, params string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat(format, args);
            textBox_console.Text += stringBuilder.ToString();
        }

        private void AddAliceChatHistory(String format, params string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("---------------------------------------------------------------------");
            stringBuilder.AppendFormat(format, args);
            AliceChatHistory.Text += stringBuilder.ToString();
        }
        private void AddBobChatHistory(String format, params string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("---------------------------------------------------------------------");
            stringBuilder.AppendFormat(format, args);
            BobChatHistory.Text += stringBuilder.ToString();
        }
    }
    
    public delegate void UserMessageEventHandler(MessageEventArgs messageEventArgs);

    public class MessageEventArgs : EventArgs
    {
        public String SendUser { get; private set; }
        public String ReceiveUser { get; private set; }
        public String Message { get; private set; }

        public MessageEventArgs(String SendUser,String ReceiveUser, String Message)
        {
            this.SendUser = SendUser;
            this.ReceiveUser = ReceiveUser;
            this.Message = Message;
        }
    }

    public class User
    {
        /// <summary>
        /// 私钥
        /// </summary>
        private String PrivateKey { get; set; }
        /// <summary>
        /// 公钥
        /// </summary>
        public String PublicKey { get; private set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public String Name { get; private set; }
        /// <summary>
        /// 用户准备消息发送时触发
        /// </summary>
        public UserMessageEventHandler onBeginUserSendMessage { get; set; }
        /// <summary>
        /// 用户完成消息发送时触发
        /// </summary>
        public UserMessageEventHandler onEndUserSendMessage { get; set; }

        /// <summary>
        /// 用户完成消息接收时触发
        /// </summary>
        public UserMessageEventHandler onBeginUserReceiveMessage { get; set; }
        /// <summary>
        /// 用户完成消息接收时触发
        /// </summary>
        public UserMessageEventHandler onEndUserReceiveMessage { get; set; }
        /// <summary>
        /// 发送角色
        /// </summary>
        public Sender Sender { get; private set; }
        /// <summary>
        /// 接收角色
        /// </summary>
        public Receiver Receiver { get; private set; }

        /// <summary>
        /// 订阅用户列表
        /// </summary>
        public IList<User> SubscriptionUser = new List<User>();
        /// <summary>
        /// 我订阅的用户
        /// </summary>
        public IList<User> MySubscriptionUser = new List<User>();
        
        /// <summary>
        /// 初始化用户
        /// </summary>
        /// <param name="Name"></param>
        public User(String Name)
        {
            this.Name = Name;
            var key = RSACrypto.CreateKey();
            PrivateKey = key.PrivateKey;
            PublicKey = key.PublicKey;
            Sender = new Sender(this, PrivateKey);
            Receiver = new Receiver(this, PrivateKey);
        }

        /// <summary>
        /// 添加订阅用户
        /// </summary>
        /// <param name="user"></param>
        private void AddSubscriptionUser(User user)
        {
            SubscriptionUser.Add(user);
        }
        /// <summary>
        /// 添加我订阅的用户
        /// </summary>
        /// <param name="user"></param>
        private void AddMySubscriptionUser(User user)
        {
            MySubscriptionUser.Add(user);
        }

        /// <summary>
        /// 订阅用户
        /// </summary>
        /// <param name="user">被订阅用户</param>
        public void Subscription(User user)
        {
            user.AddSubscriptionUser(this);
            AddMySubscriptionUser(user);
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message">消息</param>
        public void SendMessage(String message)
        {
            try
            {
                foreach (User user in SubscriptionUser)
                {
                    if (onBeginUserSendMessage != null)
                    {
                        onBeginUserSendMessage.Invoke(new MessageEventArgs(Name, user.Name, message));
                    }
                    /**
                     * 使用订阅用户公钥数据加密
                     * 数据签名 使用自己的私钥签名数据
                     * 将加密签名后的消息发送给订阅用户
                     * */
                    message = Sender.Send(user, message);

                    if (onEndUserSendMessage != null)
                    {
                        onEndUserSendMessage.Invoke(new MessageEventArgs(Name, user.Name, message));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }
        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="SendBy">发送者</param>
        /// <param name="sign">签名</param>
        /// <param name="message">加密消息</param>
        public void ReceiveMessage(String SendBy,String sign,String message)
        {
            try
            {
                User user = MySubscriptionUser.FirstOrDefault(p => p.Name.Equals(SendBy, StringComparison.CurrentCultureIgnoreCase));
                if (onBeginUserReceiveMessage != null)
                    onBeginUserReceiveMessage.Invoke(new MessageEventArgs(SendBy, Name, message));
                /**
                 * 使用发送消息用户公钥验证数据
                 * 解密数据 使用自己的私钥解密数据
                 * */
                message = Receiver.Receive(user, sign, message);

                if (onEndUserReceiveMessage != null)
                    onEndUserReceiveMessage.Invoke(new MessageEventArgs(SendBy, Name, message));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }        
    }

    /// <summary>
    /// 发送者
    /// </summary>
    public class Sender
    {
        public User User { get; private set; }
        private String PrivateKey { get; set; }
        public Sender(User User,String PrivateKey)
        {
            this.PrivateKey = PrivateKey;
            this.User = User;
        }

        /// <summary>
        /// 发送消息
        /// 1、使用接收用户公钥数据加密
        /// 2、数据签名 使用自己的私钥签名数据
        /// 3、将加密签名后的消息发送给接收用户
        /// </summary>
        /// <param name="ReceivUser">接收用户</param>
        /// <param name="Message">明文消息</param>
        public String Send(User ReceivUser,String Message)
        {
            var bytes = Encryptor(ReceivUser.PublicKey, Encoding.UTF8.GetBytes(Message));
            var signBytes = HashAndSign(bytes);
            Message = Convert.ToBase64String(bytes);
            ReceivUser.ReceiveMessage(User.Name, Convert.ToBase64String(signBytes), Message);
            return Message;
        }

        /// <summary>
        /// 对密文进行签名
        /// </summary>
        /// <param name="encrypted">密文</param>
        /// <returns>签名后密文</returns>
        public byte[] HashAndSign(byte[] encrypted)
        {
            return RSACrypto.HashAndSign(PrivateKey, encrypted);
        }

        /// <summary>
        /// 对明文进行加密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="toEncrypt"></param>
        /// <returns>密文</returns>
        public byte[] Encryptor(String key,byte[] toEncrypt)
        {
            return RSACrypto.Encryptor(toEncrypt,key);
        }
    }

    /// <summary>
    /// 接收者
    /// </summary>
    public class Receiver
    {
        public User User { get; private set; }
        private String PrivateKey { get; set; }
        public Receiver(User User, String PrivateKey)
        {
            this.PrivateKey = PrivateKey;
            this.User = User;
        }

        /// <summary>
        /// 接收消息
        /// 1、使用发送者公钥验证数据
        /// 2、解密数据 使用自己的私钥解密数据
        /// </summary>
        /// <param name="sendUser">发送用户</param>
        /// <param name="signedData">签名</param>
        /// <param name="message">密文消息</param>
        public String Receive(User sendUser, String signedData, String message)
        {
            byte[] signedDataBytes = Convert.FromBase64String(signedData),
                encryptedBytes = Convert.FromBase64String(message);

            if (VerifyHash(sendUser, signedDataBytes, encryptedBytes))
            {
                byte[] bytes = Decryptor(encryptedBytes);
                return Encoding.UTF8.GetString(bytes);
            }
            else
            {
                throw new Exception("数据验证失败，数据被篡改！");
            }
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="sendUser">发送用户</param>
        /// <param name="signe">签名</param>
        /// <param name="encrypted">密文</param>
        /// <returns></returns>
        public Boolean VerifyHash(User sendUser, byte[] signe, byte[] encrypted)
        {
            return RSACrypto.VerifyHash(sendUser.PublicKey, encrypted, signe);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="encrypted">密文</param>
        /// <returns>明文字节</returns>
        public byte[] Decryptor(byte[] encrypted)
        {
            return RSACrypto.Decryptor(encrypted, PrivateKey);
        }
    }
}
