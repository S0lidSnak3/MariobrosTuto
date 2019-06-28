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
    public class FadeAnimation : Animation
    {
        bool increase;
        float fadeSpeed;
        TimeSpan defaultTime, timer;
        bool startTimer;
        float activateValue;
        bool stopUpdating;
        float defaultAlpha;

        public override void LoadContent(ContentManager Content, Texture2D image, string text, Vector2 position)
        {
            base.LoadContent(Content, image, text, position);
            increase = false;
            fadeSpeed = 1.0f;
            defaultTime = new TimeSpan(0, 0, 1);
            timer = defaultTime;
            activateValue = 0.0f;
            stopUpdating = false;
            defaultAlpha = alpha; 
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (isActivo)
            {
                if (!stopUpdating)
                {
                    if (!increase)
                        alpha -= fadeSpeed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                    else
                        alpha += fadeSpeed = (float)gameTime.ElapsedGameTime.TotalSeconds;

                    if (alpha <= 0.0f)
                        alpha = 0.0f;
                    else if (alpha >= 1.0f)
                        alpha = 1.0f;
            
                }
            }
            else
            {
                alpha = defaultAlpha;
            }
        }
    }
}
