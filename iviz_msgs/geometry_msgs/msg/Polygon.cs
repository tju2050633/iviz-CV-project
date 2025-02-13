/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.GeometryMsgs
{
    [DataContract]
    public sealed class Polygon : IDeserializable<Polygon>, IMessage
    {
        //A specification of a polygon where the first and last points are assumed to be connected
        [DataMember (Name = "points")] public Point32[] Points;
    
        /// Constructor for empty message.
        public Polygon()
        {
            Points = System.Array.Empty<Point32>();
        }
        
        /// Explicit constructor.
        public Polygon(Point32[] Points)
        {
            this.Points = Points;
        }
        
        /// Constructor with buffer.
        public Polygon(ref ReadBuffer b)
        {
            b.DeserializeStructArray(out Points);
        }
        
        ISerializable ISerializable.RosDeserializeBase(ref ReadBuffer b) => new Polygon(ref b);
        
        public Polygon RosDeserialize(ref ReadBuffer b) => new Polygon(ref b);
    
        public void RosSerialize(ref WriteBuffer b)
        {
            b.SerializeStructArray(Points);
        }
        
        public void RosValidate()
        {
            if (Points is null) BuiltIns.ThrowNullReference();
        }
    
        public int RosMessageLength => 4 + 12 * Points.Length;
    
        /// <summary> Full ROS name of this message. </summary>
        public const string MessageType = "geometry_msgs/Polygon";
    
        public string RosMessageType => MessageType;
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        public const string Md5Sum = "cd60a26494a087f577976f0329fa120e";
    
        public string RosMd5Sum => Md5Sum;
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        public string RosDependenciesBase64 =>
                "H4sIAAAAAAAAE61RzUrEMBC+5ykG9qIgK+zeBA/iQTwIgt5EJG2m7WCaCZlZ1/r0Ttru4gPY0zSZ7zeb" +
                "O5CMLXXUeiVOwB14yByn3n6OAxYEHRA6KqLgU4DobchMSQW83XqRw4gBlKFBaDklbBWDe64r+93b+7rs" +
                "3O0/f+7p5eEGeuQRtUwfo/Ryvaq6DbwOJNWOekoyZ8gs9DejbQIl6AqileBbvDiSDrDfQUMWzrZysWrE" +
                "IJdbY3y0dQE74tECL5EPgjBrLl19YakyQk1E4xZFHyrRamsLYDwncytTCkvzdmKEufDIWsGKhTMW31Ak" +
                "nWboCTmiiO+xQgIK9Wkxo/4T4ZAh2vWSqLpKIKZBqTd05DXY+n4KnFq8skesTdSSWm+J5oJmz/eRD6Fq" +
                "uy6ytwjwfZ6m8/TjfgGp0g7/SAIAAA==";
                
    
        public override string ToString() => Extensions.ToString(this);
    }
}
