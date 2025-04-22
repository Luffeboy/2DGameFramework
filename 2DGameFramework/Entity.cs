using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameFramework
{
    public abstract class Entity
    {
        private World _world;
        private Vector2 _position;
        /// <summary>
        /// Whether or not this entity can be moved, if true, this entity can't be moved, if false, this entity can be moved
        /// </summary>
        public bool PositionIsFixed { get; protected set; } = false;
        /// <summary>
        /// Gets or sets the position of this entity
        /// When setting the position, it also updates the worlds entity grid, with this entities new position.
        /// Although altering this directly, can cause an error, if it moves outside the map. 
        /// It is recommended that you use the "MoveTo" function, if you are uncertain that the new position is inside the map
        /// </summary>
        public Vector2 Position 
        { 
            get 
            { 
                return _position;
            } set
            {
                if (PositionIsFixed)
                    return;
                _world.EntityGrid[_position.x, _position.y] = null;
                _position = value;
                _world.EntityGrid[_position.x, _position.y] = this;
            } 
        }
        /// <summary>
        /// When creating an entity, it need a start position, and a world to inhabit
        /// </summary>
        /// <param name="position"></param>
        /// <param name="world"></param>
        public Entity(Vector2 position, World world) 
        {
            _world = world;
            _position = position;
            Position = position;
        }

        /// <summary>
        /// Tries to move, an amount of tiles
        /// </summary>
        /// <param name="pos">amount to be added to the entities current position</param>
        public void Move(Vector2 pos)
        {
            Vector2 newPos = Position + pos;
            MoveTo(newPos);
        }
        /// <summary>
        /// Tries to move to the given position, but checks that it is not out of bounds before it moves.
        /// </summary>
        /// <param name="pos">The position to move to</param>
        public void MoveTo(Vector2 pos) 
        {
            if (pos.x < 0 || pos.x >= _world.WorldSize.x ||
                pos.y < 0 || pos.y >= _world.WorldSize.y)
                return;
            Position = pos;
        }
        /// <summary>
        /// Removes this entity from the world grid.
        /// Note this (also) automatically happends, when a creature dies
        /// </summary>
        protected void RemoveEntity()
        {
            _world.EntityGrid[Position.x, Position.y] = null;
        }
        /// <summary>
        /// Get the world of this entity
        /// </summary>
        /// <returns></returns>
        protected World MyWorld() 
        {
            return _world;
        }
    }
}
