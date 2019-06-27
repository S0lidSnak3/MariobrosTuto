using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.Animation
{
    public class Animation
    {
        protected Texture2D image;
        protected string text;
        protected SpriteFont font;
        protected Color color;
        protected Rectangle sourceRect;
        protected float rotation, scale, axis;
        protected Vector2 origin, position;
        protected ContentManager content;


        public virtual void LoadContent(ContentManager Content, Texture2D image, 
            string text, Vector2 position)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            this.image    = image;
            this.text     = text;
            this.position = position;

            if (text != String.Empty)
            {
                font = content.Load<SpriteFont>("AnimationFont");
                color = new Color(114,77,255);
            }

            if (image != null)
                sourceRect = new Rectangle(0, 0, image.Width, image.Height);

            rotation = 0.0f;
            axis     = 0.0f;
            scale    = 1.0f;
        }
        public virtual void UnloadContent()
        {
            content.Unload();
        }
        public virtual void Update(SpriteBatch spriteBatch)
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

    }
}
