﻿using System;
using System.IO;
using OpenTK.Graphics.OpenGL;
using WatchtowerClient.Graphics;

namespace WatchtowerClient.Assets.Shaders
{
    public class BasicShader : Shader
    {
        private int _modelLocation;
        private int _viewLocation;
        private int _projectionLocation;
        private int _cameraVectorLocation;

        public override void Initialize()
        {
            _modelLocation = GL.GetUniformLocation(ShaderProgram, "Model");
            _viewLocation = GL.GetUniformLocation(ShaderProgram, "View");
            _projectionLocation = GL.GetUniformLocation(ShaderProgram, "Projection");
            _cameraVectorLocation = GL.GetUniformLocation(ShaderProgram, "cameraVector");

            GL.UniformMatrix4(_modelLocation, false, ref Model);
            GL.UniformMatrix4(_viewLocation, false, ref View);
            GL.UniformMatrix4(_projectionLocation, false, ref Projection);
            GL.Uniform3(_cameraVectorLocation, Game.direction); // TODO: T E R R I B L E
        }
        public override void Update()
        {
            GL.UniformMatrix4(_modelLocation, false, ref Model); // TODO: is this necessary for matrices? because ref
            GL.UniformMatrix4(_viewLocation, false, ref View);
            GL.UniformMatrix4(_projectionLocation, false, ref Projection);
            GL.Uniform3(_cameraVectorLocation, Game.Camera.Position);
        }
        public BasicShader()
            : base(
                File.ReadAllText("Shaders/Basic.vs"), File.ReadAllText("Shaders/Basic.fs"),
                ShaderState.Dynamic)
        {
        }
    }
}
