using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Entity.Movement;
using GameDevelopmentProject.Interfaces;
using GameDevelopmentProject.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Level = GameDevelopmentProject.Levels.Level;

namespace GameDevelopmentProject.Entity.Combat
{
    public class CombatManager
    {
        private bool hasAttacked = false;
        private float lastAttack = 0;
        public void Update(IAttacking attacking, Level level, GameTime gameTime, Game1 game)
        {
            if (!((IHealth)attacking).IsDead)
            {
                if (attacking is Hero) //HERO ATTACKING HOSTILE
                {
                    if (attacking.CanAttack && combatInput())
                    {
                        attacking.CanAttack = false;
                        attacking.Attacking = true;
                    }

                    if (attacking.Attacking)
                    {
                        if (attacking is IAnimatable)
                        {
                            IAnimatable animatable = (IAnimatable)attacking;
                            animatable.AnimationManager.CurrentAnimationState = AnimationState.attacking;
                            if (!hasAttacked && animatable.AnimationManager.CurrentAnimation.Counter == (animatable.AnimationManager.CurrentAnimation.Frames.Count - 1) / 2)
                            {
                                hasAttacked = true;
                                List<Hostile> damagedHostiles = new List<Hostile>();
                                level.Hostiles.ForEach((e) => {
                                    if (e is IHealth && e is ICollidable)
                                    {
                                        IHealth h = (IHealth)e;
                                        ICollidable c = (ICollidable)e;
                                        if (level.Hero.AttackRange.Intersects(c.RelativeBoundingBox))
                                        {
                                            damagedHostiles.Add((Hostile)h);
                                        }
                                    }
                                });

                                damagedHostiles.ForEach((e) =>
                                {
                                    Damage(e, level.Hero.Damage, level, game);
                                });
                            }
                            if (animatable.AnimationManager.CurrentAnimation.Counter == animatable.AnimationManager.CurrentAnimation.Frames.Count - 1)
                            {
                                animatable.AnimationManager.CurrentAnimation.Counter = 0;
                                attacking.Attacking = false;
                            }
                        }
                    }

                    if (attacking.Attacking == false && !attacking.CanAttack && !combatInput())
                    {
                        attacking.CanAttack = true;
                        hasAttacked = false;
                    }
                }
                else if (attacking is Hostile) // HOSTILE ATTACKING HERO
                {
                    if(!hasAttacked || lastAttack >= 1f)
                    {
                        if (attacking is ICollidable)
                        {
                            IHealth h = (IHealth)attacking;
                            ICollidable c = (ICollidable)attacking;
                            if (c.RelativeBoundingBox.Intersects(level.Hero.RelativeBoundingBox))
                            {
                                hasAttacked = true;
                                lastAttack = 0f;
                                Damage(level.Hero, level.Hero.Damage, level, game);
                            }
                        }
                    }
                    else
                    {
                        lastAttack += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                }
            }
        }

        public void Damage(IHealth health, int damage, Level level, Game1 game)
        {
            health.CurrentHealthPoints -= damage;
            if(health.CurrentHealthPoints <= 0)
            {
                health.IsDead = true;
                ((IAnimatable)health).AnimationManager.CurrentAnimationState = AnimationState.dead;
                if (health is Hero && ((IAnimatable)health).AnimationManager.CurrentAnimation.Counter == ((IAnimatable)health).AnimationManager.CurrentAnimation.Frames.Count-1)
                    game.GameState = GameState.GameOver;
            }
            else
            {
                ((IAnimatable)health).AnimationManager.CurrentAnimationState = AnimationState.hit;
            }
        }

        private bool combatInput()
        {
            return (Mouse.GetState().LeftButton == ButtonState.Pressed);
        }
    }
}
