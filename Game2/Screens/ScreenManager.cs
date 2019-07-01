using Game2.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Screens
{
    public class ScreenManager
    {
        #region Variables

        /// <summary>
        /// Creando contenido personalizado
        /// </summary>
        ContentManager content;

        GameScreen currentScreen;
        GameScreen newScreen;

        /// <summary>
        /// Instancia del ScreenManager
        /// </summary>
        private static ScreenManager instance;

        /// <summary>
        /// Screen Stack
        /// </summary>
        Stack<GameScreen> screenStack = new Stack<GameScreen>();

        /// <summary>
        /// Ancho y Alto de pantalla alv.
        /// </summary>
        Vector2 dimensions;

        /// <summary>
        /// Tendra transicion o no
        /// </summary>
        bool transition;
        FadeAnimation fade;

        Texture2D fadeTexture;

        #endregion

        #region Propiedades

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();
                return instance;
            }
        }

        public Vector2 Dimensions
        {
            get { return dimensions; }
            set { dimensions = value; }
        }
        #endregion

        #region Metodos Principales

        public void AddScreen(GameScreen screen)
        {
            transition = true;
            newScreen = screen;
            fade.IsActivo = true;
            fade.Alpha = 0.0f;
            fade.ActivateValue = 1.0f;
        }
        public void Initialize()
        {
            currentScreen = new SplashScreen();
            fade = new FadeAnimation();
        }
        public void LoadContent(ContentManager Content)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent(Content);
            fadeTexture = content.Load<Texture2D>("fade");
            fade.LoadContent(Content, fadeTexture, "", Vector2.Zero);
            fade.Scale = dimensions.X;

        }
        public void Update(GameTime gameTime)
        {
            if (!transition)
                currentScreen.Update(gameTime);
            else
                Transition(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
            if (transition)
                fade.Draw(spriteBatch);
        }

        #endregion

        #region Metodos Privados

        private void Transition(GameTime gameTime)
        {
            fade.Update(gameTime);
            if(fade.Alpha == 1.0f && fade.Timer.TotalSeconds == 1.0f)
            {
                screenStack.Push(newScreen);
                currentScreen.UnloadContent();
                currentScreen = newScreen;
                currentScreen.LoadContent(content);
            }
            else if(fade.Alpha == 0.0f)
            {
                transition = false;
                fade.IsActivo = false;
            }
        }
        #endregion
    }
}
