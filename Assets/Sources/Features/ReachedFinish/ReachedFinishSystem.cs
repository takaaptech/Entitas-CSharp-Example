﻿using Entitas;

public class ReachedFinishSystem : IReactiveSystem, ISetPool {
    public IMatcher GetTriggeringMatcher() {
        return CoreMatcher.Position;
    }

    public GroupEventType GetEventType() {
        return GroupEventType.OnEntityAdded;
    }

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Execute(Entity[] entities) {
        var finishLinePosY = _pool.finishLineEntity.position.y;
        foreach (var e in entities) {
            if (e.position.y > finishLinePosY) {
                e.isDestroy = true;
            }
        }
    }
}

