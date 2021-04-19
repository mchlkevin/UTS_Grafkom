using LearnOpenTK.Common;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenTK.Graphics.OpenGL4;

namespace ComputerGraphics
{
    class NewMesh
    {
        //Vector 3 pastikan menggunakan OpenTK.Mathematics
        //tanpa protected otomatis komputer menganggap sebagai private
         List<Vector3> vertices = new List<Vector3>();
         List<Vector3> textureVertices = new List<Vector3>();
         List<Vector3> normals = new List<Vector3>();
         List<uint> vertexIndices = new List<uint>();
         int _vertexBufferObject;
         int _elementBufferObject;
         int _vertexArrayObject;
         Shader _shader;
         Matrix4 transform;
        int counter = 0;
        public List<NewMesh> child = new List<NewMesh>();
        public NewMesh()
        {
        }
        public void loadShaderfromPath(string path)
        {
            string temp = path,
                   frag = path += ".frag",
                   vert = temp += ".vert";

            _shader = new Shader(vert, frag);
        }
        public void setupObject(string shaderPath)
        {

            //inisialisasi Transformasi
            transform = Matrix4.Identity;
            //inisialisasi buffer
            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            //parameter 2 yg kita panggil vertices.Count == array.length
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, 
                vertices.Count * Vector3.SizeInBytes, 
                vertices.ToArray(), 
                BufferUsageHint.StaticDraw);
            //inisialisasi array
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            //inisialisasi index vertex
            _elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
            //parameter 2 dan 3 perlu dirubah
            GL.BufferData(BufferTarget.ElementArrayBuffer, 
                vertexIndices.Count * sizeof(uint), 
                vertexIndices.ToArray(), BufferUsageHint.StaticDraw);
            //inisialisasi shader
            loadShaderfromPath(shaderPath);
            _shader.Use();
        }
        
        public void render()
        {
            _shader.Use();

            _shader.SetMatrix4("transform", transform);
            GL.BindVertexArray(_vertexArrayObject);
            //perlu diganti di parameter 2
            GL.DrawElements(PrimitiveType.Triangles, 
                vertexIndices.Count, 
                DrawElementsType.UnsignedInt, 0);

            foreach (var meshobj in child)
            {
                meshobj.render();
            }
        }
        public List<Vector3> getVertices()
        {
            return vertices;
        }
        public List<uint> getVertexIndices()
        {
            return vertexIndices;
        }

        public void setVertexIndices(List<uint> temp)
        {
            vertexIndices = temp;
        }
        public int getVertexBufferObject()
        {
            return _vertexBufferObject;
        }

        public int getElementBufferObject()
        {
            return _elementBufferObject;
        }

        public int getVertexArrayObject()
        {
            return _vertexArrayObject;
        }

        public Shader getShader()
        {
            return _shader;
        }

        public Matrix4 getTransform()
        {
            return transform;
        }

        public void rotateX(float value = 0.5f)
        {
            //rotate parentnya
            //sumbu X
            transform = transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(value));

            //rotate childnya
            foreach (var meshobj in child)
            {
                meshobj.rotateX(value);
            }
        }
        public void rotateY(float value = 0.5f)
        {
            //rotate parentnya
            //sumbu Y
            transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(value));

            //rotate childnya
            foreach (var meshobj in child)
            {
                meshobj.rotateY(value);
            }
        }
        public void rotateZ(float value = 0.5f)
        {
            //rotate parentnya
            //sumbu Z
            transform = transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(value));

            //rotate childnya
            foreach (var meshobj in child)
            {
                meshobj.rotateZ(value);
            }
        }

        public void scale(float value)
        {
            transform = transform * Matrix4.CreateScale(value);
        }

        //translasi perpindahan suatu objek ke posisi lain
        public void translate(float valueX = 0.0f, float valueY = 0.0f, float valueZ = 0.0f)
        {
            transform = transform * Matrix4.CreateTranslation(valueX, valueY, valueZ);
        }

        public void LoadObjFile(string path)
        {
            //komputer ngecek, apakah file bisa diopen atau tidak
            if (!File.Exists(path))
            {
                //mengakhiri program dan kita kasih peringatan
                throw new FileNotFoundException("Unable to open \"" + path + "\", does not exist.");
            }
            //lanjut ke sini
            using (StreamReader streamReader = new StreamReader(path))
            {
                while (!streamReader.EndOfStream)
                {
                    //aku ngambil 1 baris tersebut -> dimasukkan ke dalam List string -> dengan di split pakai spasi
                    List<string> words = new List<string>(streamReader.ReadLine().ToLower().Split(' '));
                    //removeAll(kondisi dimana penghapusan terjadi)
                    words.RemoveAll(s => s == string.Empty);
                    //Melakukan pengecekkan apakah dalam satu list -> ada isinya atau tidak list nya tersebut
                    //kalau ada continue, perintah-perintah yang ada dibawahnya tidak akan dijalankan 
                    //dan dia bakal kembali keatas lagi / melanjutkannya whilenya
                    if (words.Count == 0)
                        continue;

                    //System.Console.WriteLine("New While");
                    //foreach (string x in words)
                    //               {
                    //	System.Console.WriteLine("tes");
                    //	System.Console.WriteLine(x);
                    //               }

                    string type = words[0];
                    //remove at -> menghapus data dalam suatu indexs dan otomatis data pada indeks
                    //berikutnya itu otomatis mundur kebelakang 1
                    words.RemoveAt(0);
                    

                    switch (type)
                    {
                        // vertex
                        //parse merubah dari string ke tipe variabel yang diinginkan
                        //ada /10 karena saaat ini belum masuk materi camera
                        case "v":
                            vertices.Add(new Vector3(float.Parse(words[0])/10, float.Parse(words[1])/10, float.Parse(words[2])/10));
                            break;

                        case "vt":
                            textureVertices.Add(new Vector3(float.Parse(words[0]), float.Parse(words[1]),
                                                            words.Count < 3 ? 0 : float.Parse(words[2])));
                            break;

                        case "vn":
                            normals.Add(new Vector3(float.Parse(words[0]), float.Parse(words[1]), float.Parse(words[2])));
                            break;
                        // face
                        case "f":
                            foreach (string w in words)
                            {
                                if (w.Length == 0)
                                    continue;

                                string[] comps = w.Split('/');

                                vertexIndices.Add(uint.Parse(comps[0]) - 1);

                            }
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        public void createBoxVertices(float x,float y,float z)
        {
            //biar lebih fleksibel jangan inisialiasi posisi dan 
            //panjang kotak didalam tapi ditaruh ke parameter
            float _positionX = x;
            float _positionY = y;
            float _positionZ = z;
            
            float _boxLength = 0.05f;

            //Buat temporary vector
            Vector3 temp_vector;
            //1. Inisialisasi vertex
            // Titik 1
            temp_vector.X = _positionX - _boxLength / 2.0f; // x 
            temp_vector.Y = _positionY + _boxLength / 2.0f; // y
            temp_vector.Z = _positionZ - _boxLength / 2.0f; // z

            vertices.Add(temp_vector);

            // Titik 2
            temp_vector.X = _positionX + _boxLength / 2.0f; // x
            temp_vector.Y = _positionY + _boxLength / 2.0f; // y
            temp_vector.Z = _positionZ - _boxLength / 2.0f; // z

            vertices.Add(temp_vector);
            // Titik 3
            temp_vector.X = _positionX - _boxLength / 2.0f; // x
            temp_vector.Y = _positionY - _boxLength / 2.0f; // y
            temp_vector.Z = _positionZ - _boxLength / 2.0f; // z
            vertices.Add(temp_vector);

            // Titik 4
            temp_vector.X = _positionX + _boxLength / 2.0f; // x
            temp_vector.Y = _positionY - _boxLength / 2.0f; // y
            temp_vector.Z = _positionZ - _boxLength / 2.0f; // z

            vertices.Add(temp_vector);

            // Titik 5
            temp_vector.X = _positionX - _boxLength / 2.0f; // x
            temp_vector.Y = _positionY + _boxLength / 2.0f; // y
            temp_vector.Z = _positionZ + _boxLength / 2.0f; // z

            vertices.Add(temp_vector);

            // Titik 6
            temp_vector.X = _positionX + _boxLength / 2.0f; // x
            temp_vector.Y = _positionY + _boxLength / 2.0f; // y
            temp_vector.Z = _positionZ + _boxLength / 2.0f; // z

            vertices.Add(temp_vector);

            // Titik 7
            temp_vector.X = _positionX - _boxLength / 2.0f; // x
            temp_vector.Y = _positionY - _boxLength / 2.0f; // y
            temp_vector.Z = _positionZ + _boxLength / 2.0f; // z

            vertices.Add(temp_vector);

            // Titik 8
            temp_vector.X = _positionX + _boxLength / 2.0f; // x
            temp_vector.Y = _positionY - _boxLength / 2.0f; // y
            temp_vector.Z = _positionZ + _boxLength / 2.0f; // z

            vertices.Add(temp_vector);
            //2. Inisialisasi index vertex
            vertexIndices = new List<uint> {
                // Segitiga Depan 1
                0, 1, 2,
                // Segitiga Depan 2
                1, 2, 3,
                // Segitiga Atas 1
                0, 4, 5,
                // Segitiga Atas 2
                0, 1, 5,
                // Segitiga Kanan 1
                1, 3, 5,
                // Segitiga Kanan 2
                3, 5, 7,
                // Segitiga Kiri 1
                0, 2, 4,
                // Segitiga Kiri 2
                2, 4, 6,
                // Segitiga Belakang 1
                4, 5, 6,
                // Segitiga Belakang 2
                5, 6, 7,
                // Segitiga Bawah 1
                2, 3, 6,
                // Segitiga Bawah 2
                3, 6, 7
            };

        }
    }
}
