using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class Serializer
    {
        public static byte[] SerializeToByteArray<T>(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static T DeserializeFromByteArray<T>(byte[] byteArray)
        {
            if (byteArray == null)
            {
                throw new ArgumentNullException(nameof(byteArray));
            }

            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return (T)formatter.Deserialize(ms);
            }
        }
}

public static class ReflectionSerializer
{
    public static byte[] Serialize<T>(T obj)
    {
        using (MemoryStream ms = new MemoryStream())
        using (BinaryWriter writer = new BinaryWriter(ms))
        {
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                object value = property.GetValue(obj);
                if (value is int)
                    writer.Write((int)value);
                else if (value is string)
                    writer.Write((string)value);
                // Dodaj obsługę innych typów danych według potrzeb
            }
            return ms.ToArray();
        }
    }

    public static T Deserialize<T>(byte[] data) where T : new()
    {
        T obj = new T();
        using (MemoryStream ms = new MemoryStream(data))
        using (BinaryReader reader = new BinaryReader(ms))
        {
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                if (property.PropertyType == typeof(int))
                    property.SetValue(obj, reader.ReadInt32());
                else if (property.PropertyType == typeof(string))
                    property.SetValue(obj, reader.ReadString());
                // Dodaj obsługę innych typów danych według potrzeb
            }
        }
        return obj;
    }

}

public static class SpriteSerializer
{
    public static byte[] Serialize(Sprite sprite)
    {
        Texture2D texture = sprite.texture;
        texture=ExtensionMethod.DeCompress(texture);
        byte[] bytes = texture.EncodeToPNG(); // Możesz użyć też EncodeToJPG dla mniejszych plików
        return bytes;
    }

    public static void SaveSpriteToFile(Sprite sprite, string filePath)
    {
        byte[] bytes = Serialize(sprite);
        File.WriteAllBytes(filePath, bytes);
    }
}
public static class SpriteDeserializer
{
    public static Sprite Deserialize(byte[] bytes, float pixelsPerUnit = 1000.0f)
    {
        Vector2 pivot = new Vector2(0.5f, 0.5f);
        // Create a new Texture2D and load the image data
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(bytes);
        // Create a new Sprite from the Texture2D
        Rect rect = new Rect(0, 0, texture.width, texture.height);
        Sprite sprite = Sprite.Create(texture, rect, pivot, pixelsPerUnit);
        return sprite;
    }
}
public static class ExtensionMethod
{
    public static Texture2D DeCompress(this Texture2D source)
    {
        RenderTexture renderTex = RenderTexture.GetTemporary(
                    source.width,
                    source.height,
                    0,
                    RenderTextureFormat.Default,
                    RenderTextureReadWrite.Linear);

        Graphics.Blit(source, renderTex);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTex;
        Texture2D readableText = new Texture2D(source.width, source.height);
        readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
        readableText.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTex);
        return readableText;
    }
}