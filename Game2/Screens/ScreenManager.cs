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
            newScreen = screen;
            screenStack.Push(screen);
        }
        public void Initialize() { }
        public void LoadContent(ContentManager Content) { }
        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }

        #endregion
    }
}
