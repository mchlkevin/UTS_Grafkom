using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using LearnOpenTK.Common;
using System.IO;
using OpenTK.Windowing.GraphicsLibraryFramework;


namespace ComputerGraphics
{
    class Window8 : GameWindow
    {
        //Car
        NewMesh carChasis = new NewMesh(),
                carFWheels = new NewMesh(),
                carBWheels = new NewMesh(),
                carAccessories = new NewMesh(),
                carCurve = new NewMesh();

        //Path
        string pathCChasis = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Mobil/carChasis.obj",
               pathCFWheels = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Mobil/rodaDepan.obj",
               pathCBWheels = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Mobil/rodaBelakang.obj",
               pathCAccessories = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Mobil/carAccessories.obj",
               pathCCurve= "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Mobil/carCurve.obj",
               pathCFWheelShader = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Mobil/carWheel",
               pathCBWheelShader = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Mobil/carWheel",
               pathCChasisShader = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Mobil/carChasis",
               pathCCurveShader = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Mobil/carWheel",
               pathCAccessoriesShader = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Mobil/carAccessories";

        //Van
        NewMesh vanChasis = new NewMesh(),
                vanCurve = new NewMesh(),
                vanWindow = new NewMesh(),
                vanAccessories = new NewMesh(),
                vanFWheel = new NewMesh(),
                vanBWheel = new NewMesh(),
                vanLight = new NewMesh();

        //Path
        string pathVChasis = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Van/vanChassis.obj",
               pathVCurve = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Van/vanCurve.obj",
               pathVWindow = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Van/vanWindow.obj",
               pathVAc = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Van/vanAccessories.obj",
               pathVFWheel = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Van/rodaDepan.obj",
               pathVBWheel = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Van/rodaBelakang.obj",
               pathVLight = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Van/lampuDepan.obj",

               pathVChasisS = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Van/chasis",
               pathVCurveS = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Van/roda",
               pathVWindowS = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Van/window",
               pathVAcS = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Van/accessories",
               pathVFWheelS = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Van/roda",
               pathVBWheelS = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Van/roda",
               pathVlLightS = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Van/accessories";


        //Truck
        NewMesh truckChasis = new NewMesh(),
                truckContainer1 = new NewMesh(),
                truckContainer2 = new NewMesh(),
                truckCurves = new NewMesh(),
                truckFrontWheels = new NewMesh(),
                truckPoles = new NewMesh(),
                truckWheels = new NewMesh(),
                truckWindow = new NewMesh();

        string pathTChasisS = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Truck/Red",
               pathTC1S = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Truck/Red",
               pathTC2S = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Truck/Yellow",
               pathTCurveS = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Truck/Black",
               pathTFWS = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Truck/Black",
               pathTPolesS = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Truck/Black",
               pathTWS = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Truck/Black",
               pathTWindowS = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Truck/Window",

               pathTChasis = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Truck/truckChassis.obj",
               pathTC1 = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Truck/truckContainer1.obj",
               pathTC2 = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Truck/truckContainer2.obj",
               pathTCurve = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Truck/truckCurves.obj",
               pathTFW = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Truck/truckFrontWheels.obj",
               pathTPoles = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Truck/truckPoles.obj",
               pathTW = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Truck/truckWheels.obj",
               pathTWindow = "C:/Users/Andy Pangadiansjah/source/repos/ComputerGraphics/ComputerGraphics/Assets/Truck/truckWindow.obj";

        //Utility
        float timeLapsedCar = 0.0f,
              timeLapsedTruck = 0.0f,
              timeLapsedVan = 0.0f;

        public Window8(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        public void loadCar()
        {
            //OBJ File
            carChasis.LoadObjFile(pathCChasis);
            carFWheels.LoadObjFile(pathCFWheels);
            carBWheels.LoadObjFile(pathCBWheels);
            carCurve.LoadObjFile(pathCCurve);
            carAccessories.LoadObjFile(pathCAccessories);

            //Setup + Shader
            carChasis.setupObject(pathCChasisShader);
            carFWheels.setupObject(pathCFWheelShader);
            carBWheels.setupObject(pathCBWheelShader);
            carCurve.setupObject(pathCCurveShader);
            carAccessories.setupObject(pathCAccessoriesShader);
        }
        public void loadTruck()
        {
            //OBJ File
            truckChasis.LoadObjFile(pathTChasis);
            truckContainer1.LoadObjFile(pathTC1);
            truckContainer2.LoadObjFile(pathTC2);
            truckCurves.LoadObjFile(pathTCurve);
            truckFrontWheels.LoadObjFile(pathTFW);
            truckPoles.LoadObjFile(pathTPoles);
            truckWheels.LoadObjFile(pathTW);
            truckWindow.LoadObjFile(pathTWindow);

            //Setup + Shader
            truckChasis.setupObject(pathTChasisS);
            truckContainer1.setupObject(pathTC1S);
            truckContainer2.setupObject(pathTC2S);
            truckCurves.setupObject(pathTCurveS);
            truckFrontWheels.setupObject(pathTFWS);
            truckPoles.setupObject(pathTPolesS);
            truckWheels.setupObject(pathTWS);
            truckWindow.setupObject(pathTWindowS);

            //Child
            
        }
        public void loadVan()
        {
            //OBJ File
            vanChasis.LoadObjFile(pathVChasis);
            vanCurve.LoadObjFile(pathVCurve);
            vanWindow.LoadObjFile(pathVWindow);
            vanAccessories.LoadObjFile(pathVAc);
            vanFWheel.LoadObjFile(pathVFWheel);
            vanBWheel.LoadObjFile(pathVBWheel);
            vanLight.LoadObjFile(pathVLight);

            //Setup + Shader
            vanChasis.setupObject(pathVChasisS);
            vanCurve.setupObject(pathVCurveS);
            vanWindow.setupObject(pathVWindowS);
            vanAccessories.setupObject(pathVAcS);
            vanFWheel.setupObject(pathVFWheelS);
            vanBWheel.setupObject(pathVBWheelS);
            vanLight.setupObject(pathVlLightS);
        }

        public void truckRender()
        {
            truckContainer1.render();
            truckContainer2.render();
            truckCurves.render();
            truckFrontWheels.render();
            truckPoles.render();
            truckWheels.render();
            truckChasis.render();
            truckWindow.render();
        }
        public void carRender()
        {
            carChasis.render();
            carFWheels.render();
            carBWheels.render();
            carCurve.render();
            carAccessories.render();
        }
        public void vanRender()
        {
            vanCurve.render();
            vanWindow.render();
            vanFWheel.render();
            vanBWheel.render();
            vanChasis.render();
            vanLight.render();
            vanAccessories.render();
        }

        public void truckAnimate()
        {
            //Sequence
            //1. Mundur (Scaling )
            //2. Rotate ke kiri
            //3. Translate ke kanan
            //4. Rotate ke Kiri
            //5. Maju
            //6. U Turn (Di luar layar)
            //7. Maju terus ke depan sampai hilang (Translate , Scalling )

            Console.WriteLine(timeLapsedTruck);
            if (timeLapsedTruck <= 3.0f)
            {
                //Mundur
                truckChasis.scale(1.001f);
                truckContainer1.scale(1.001f);
                truckContainer2.scale(1.001f);
                truckCurves.scale(1.001f);
                truckFrontWheels.scale(1.001f);
                truckPoles.scale(1.001f);
                truckWheels.scale(1.001f);
                truckWindow.scale(1.001f);

                //Rotate
                truckChasis.rotateY();
                truckContainer1.rotateY();
                truckContainer2.rotateY();
                truckCurves.rotateY();
                truckFrontWheels.rotateY();
                truckPoles.rotateY();
                truckWheels.rotateY();
                truckWindow.rotateY();
            }
            else if (timeLapsedTruck <= 3.5f)
            {
                //Translate ke Kanan
                truckChasis.translate(0.01f);
                truckContainer1.translate(0.01f);
                truckContainer2.translate(0.01f);
                truckCurves.translate(0.01f);
                truckFrontWheels.translate(0.01f);
                truckPoles.translate(0.01f);
                truckWheels.translate(0.01f);
                truckWindow.translate(0.01f);
            }
            else if (timeLapsedTruck <= 6.7f)
            {
                //Rotate ke kanan
                truckChasis.rotateY();
                truckContainer1.rotateY();
                truckContainer2.rotateY();
                truckCurves.rotateY();
                truckFrontWheels.rotateY();
                truckPoles.rotateY();
                truckWheels.rotateY();
                truckWindow.rotateY();

            }
            else if (timeLapsedTruck < 8.7f)
            {
                //Maju
                truckChasis.scale(1.01f);
                truckContainer1.scale(1.01f);
                truckContainer2.scale(1.01f);
                truckCurves.scale(1.01f);
                truckFrontWheels.scale(1.01f);
                truckPoles.scale(1.01f);
                truckWheels.scale(1.01f);
                truckWindow.scale(1.01f);
            }
            else if (timeLapsedTruck < 14.7f)
            {
                //U-Turn
                truckChasis.rotateY(-0.5f);
                truckContainer1.rotateY(-0.5f);
                truckContainer2.rotateY(-0.5f);
                truckCurves.rotateY(-0.5f);
                truckFrontWheels.rotateY(-0.5f);
                truckPoles.rotateY(-0.5f);
                truckWheels.rotateY(-0.5f);
                truckWindow.rotateY(-0.5f);
            }
            else if (timeLapsedTruck < 16.7f)
            {
                truckChasis.scale(0.97f);
                truckContainer1.scale(0.97f);
                truckContainer2.scale(0.97f);
                truckCurves.scale(0.97f);
                truckFrontWheels.scale(0.97f);
                truckPoles.scale(0.97f);
                truckWheels.scale(0.97f);
                truckWindow.scale(0.97f);
            }
            else if (timeLapsedTruck < 22.7f)
            {
                truckChasis.rotateY(0.5f);
                truckContainer1.rotateY(0.5f);
                truckContainer2.rotateY(0.5f);
                truckCurves.rotateY(0.5f);
                truckFrontWheels.rotateY(0.5f);
                truckPoles.rotateY(0.5f);
                truckWheels.rotateY(0.5f);
                truckWindow.rotateY(0.5f);
            }
            else
            {
                truckChasis.scale(1.01f);
                truckContainer1.scale(1.01f);
                truckContainer2.scale(1.01f);
                truckCurves.scale(1.01f);
                truckFrontWheels.scale(1.01f);
                truckPoles.scale(1.01f);
                truckWheels.scale(1.01f);
                truckWindow.scale(1.01f);

                if (timeLapsedTruck > 24.7f)
                    timeLapsedTruck = 8.7f;
            }

        }
        public void carAnimate()
        { 
            //Sequence
            //1. Mundur (Scaling )
            //2. Rotate ke kiri
            //3. Translate ke kanan
            //4. Rotate ke Kiri
            //5. Maju
            //6. U Turn (Di luar layar)
            //7. Maju terus ke depan sampai hilang (Translate , Scalling )

            if (timeLapsedCar <= 3.0f)
            {
                //Mundur
                carChasis.scale(1.001f);
                carBWheels.scale(1.001f);
                carFWheels.scale(1.001f);
                carCurve.scale(1.001f);
                carAccessories.scale(1.001f);

                //Rotate
                carChasis.rotateY(-0.5f);
                carBWheels.rotateY(-0.5f);
                carFWheels.rotateY(-0.5f);
                carCurve.rotateY(-0.5f);
                carAccessories.rotateY(-0.5f);
            }
            else if (timeLapsedCar <= 3.5f)
            {
                //Translate ke Kiri
                carChasis.translate(-0.01f);
                carBWheels.translate(-0.01f);
                carFWheels.translate(-0.01f);
                carCurve.translate(-0.01f);
                carAccessories.translate(-0.01f);
            }
            else if (timeLapsedCar <= 6.7f)
            {
                //Rotate
                carChasis.rotateY(-0.5f);
                carBWheels.rotateY(-0.5f);
                carFWheels.rotateY(-0.5f);
                carCurve.rotateY(-0.5f);
                carAccessories.rotateY(-0.5f);

            }
            else if (timeLapsedCar <= 10.0f)
            {
                //Maju
                carChasis.scale(0.97f);
                carBWheels.scale(0.97f);
                carFWheels.scale(0.97f);
                carCurve.scale(0.97f);
                carAccessories.scale(0.97f);
            }
            else if (timeLapsedCar <= 16.0f)
            {
                //U-Turn
                carChasis.rotateY(0.5f);
                carBWheels.rotateY(0.5f);
                carFWheels.rotateY(0.5f);
                carCurve.rotateY(0.5f);
                carAccessories.rotateY(0.5f);
            }
            else if (timeLapsedCar <= 19.3f)
            {
                carChasis.scale(1.01f);
                carBWheels.scale(1.01f);
                carFWheels.scale(1.01f);
                carCurve.scale(1.01f);
                carAccessories.scale(1.01f);
            }
            else if (timeLapsedCar <= 25.3f)
            {
                carChasis.rotateY(0.5f);
                carBWheels.rotateY(0.5f);
                carFWheels.rotateY(0.5f);
                carCurve.rotateY(0.5f);
                carAccessories.rotateY(0.5f);
            }
            else
            {
                carChasis.scale(1.01f);
                carBWheels.scale(1.01f);
                carFWheels.scale(1.01f);
                carCurve.scale(1.01f);
                carAccessories.scale(1.01f);

                if (timeLapsedCar >= 28.6f)
                    timeLapsedCar = 10.1f;
            }
        }
        public void vanAnimate()
        {

            if (KeyboardState.IsKeyDown(Keys.S))
            {
                vanChasis.scale(1.01f);
                vanAccessories.scale(1.01f);
                vanFWheel.scale(1.01f);
                vanBWheel.scale(1.01f);
                vanWindow.scale(1.01f);
                vanCurve.scale(1.01f);
                vanLight.scale(1.01f);
            }
            else if (KeyboardState.IsKeyDown(Keys.W))
            {
                vanChasis.scale(0.99f);
                vanAccessories.scale(0.99f);
                vanFWheel.scale(0.99f);
                vanBWheel.scale(0.99f);
                vanWindow.scale(0.99f);
                vanCurve.scale(0.99f);
                vanLight.scale(0.99f);
            }
            else if (KeyboardState.IsKeyDown(Keys.D))
            {
                vanChasis.translate(0.01f);
                vanAccessories.translate(0.01f);
                vanFWheel.translate(0.01f);
                vanBWheel.translate(0.01f);
                vanWindow.translate(0.01f);
                vanCurve.translate(0.01f);
                vanLight.translate(0.01f);
            }
            else if (KeyboardState.IsKeyDown(Keys.A))
            {
                vanChasis.translate(-0.01f);
                vanAccessories.translate(-0.01f);
                vanFWheel.translate(-0.01f);
                vanBWheel.translate(-0.01f);
                vanWindow.translate(-0.01f);
                vanCurve.translate(-0.01f);
                vanLight.translate(-0.01f);
            }
            else if (KeyboardState.IsKeyDown(Keys.Q))
            {
                vanChasis.rotateY(0.7f);
                vanAccessories.rotateY(0.7f);
                vanFWheel.rotateY(0.7f);
                vanBWheel.rotateY(0.7f);
                vanWindow.rotateY(0.7f);
                vanCurve.rotateY(0.7f);
                vanLight.rotateY(0.7f);
            }
            else if (KeyboardState.IsKeyDown(Keys.E))
            {
                vanChasis.rotateY(-0.7f);
                vanAccessories.rotateY(-0.7f);
                vanFWheel.rotateY(-0.7f);
                vanBWheel.rotateY(-0.7f);
                vanWindow.rotateY(-0.7f);
                vanCurve.rotateY(-0.7f);
                vanLight.rotateY(-0.7f);
            }
        }
        protected override void OnLoad()
        {
            GL.ClearColor(Color4.DarkKhaki);

            //Car
            loadCar();

            //Truck
            loadTruck();

            //Van
            loadVan();

            //Special Properties


            base.OnLoad();
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            carAnimate();
            truckAnimate();
            vanAnimate();

            truckRender();
            carRender();
            vanRender();

            SwapBuffers();
            base.OnRenderFrame(args);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            timeLapsedCar += (float)args.Time;
            timeLapsedTruck += (float)args.Time;
           // timeLapsedVan += (float)args.Time;

            base.OnUpdateFrame(args);
        }
    }
}
