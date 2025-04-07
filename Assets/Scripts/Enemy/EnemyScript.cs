namespace Enemy
{
    public class EnemyScript : EnemyAbstract
    {
        protected new void Start() => base.Start();

        protected override void PerformAction() => Update();
    }
}