/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.Tf2Msgs
{
    [DataContract]
    public sealed class LookupTransformGoal : IDeserializable<LookupTransformGoal>, IGoal<LookupTransformActionGoal>
    {
        //Simple API
        [DataMember (Name = "target_frame")] public string TargetFrame;
        [DataMember (Name = "source_frame")] public string SourceFrame;
        [DataMember (Name = "source_time")] public time SourceTime;
        [DataMember (Name = "timeout")] public duration Timeout;
        //Advanced API
        [DataMember (Name = "target_time")] public time TargetTime;
        [DataMember (Name = "fixed_frame")] public string FixedFrame;
        //Whether or not to use the advanced API
        [DataMember (Name = "advanced")] public bool Advanced;
    
        /// Constructor for empty message.
        public LookupTransformGoal()
        {
            TargetFrame = "";
            SourceFrame = "";
            FixedFrame = "";
        }
        
        /// Constructor with buffer.
        public LookupTransformGoal(ref ReadBuffer b)
        {
            b.DeserializeString(out TargetFrame);
            b.DeserializeString(out SourceFrame);
            b.Deserialize(out SourceTime);
            b.Deserialize(out Timeout);
            b.Deserialize(out TargetTime);
            b.DeserializeString(out FixedFrame);
            b.Deserialize(out Advanced);
        }
        
        ISerializable ISerializable.RosDeserializeBase(ref ReadBuffer b) => new LookupTransformGoal(ref b);
        
        public LookupTransformGoal RosDeserialize(ref ReadBuffer b) => new LookupTransformGoal(ref b);
    
        public void RosSerialize(ref WriteBuffer b)
        {
            b.Serialize(TargetFrame);
            b.Serialize(SourceFrame);
            b.Serialize(SourceTime);
            b.Serialize(Timeout);
            b.Serialize(TargetTime);
            b.Serialize(FixedFrame);
            b.Serialize(Advanced);
        }
        
        public void RosValidate()
        {
            if (TargetFrame is null) BuiltIns.ThrowNullReference();
            if (SourceFrame is null) BuiltIns.ThrowNullReference();
            if (FixedFrame is null) BuiltIns.ThrowNullReference();
        }
    
        public int RosMessageLength
        {
            get {
                int size = 37;
                size += BuiltIns.GetStringSize(TargetFrame);
                size += BuiltIns.GetStringSize(SourceFrame);
                size += BuiltIns.GetStringSize(FixedFrame);
                return size;
            }
        }
    
        /// <summary> Full ROS name of this message. </summary>
        public const string MessageType = "tf2_msgs/LookupTransformGoal";
    
        public string RosMessageType => MessageType;
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        public const string Md5Sum = "35e3720468131d675a18bb6f3e5f22f8";
    
        public string RosMd5Sum => Md5Sum;
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        public string RosDependenciesBase64 =>
                "H4sIAAAAAAAAEzWMQQqAMAwE7/uK/kyiTUvANpCm4vOlGm+7wzAYbtJrcrLKvhWjxgg2dNrBwVwa/2Rt" +
                "5Gnkoj2tp9OBz4nS60SoyM05OsCueibKF/WDM/AACrcOXIIAAAA=";
                
    
        public override string ToString() => Extensions.ToString(this);
    }
}
