using NUnit.Framework;
using UnityEngine;
using UnityFoundation.Code.Features;
using UnityFoundation.TestUtility;

namespace UnityFoundation.Code.Tests
{
    public class ObjectPoolingTests
    {
        [Test]
        public void Should_instantiate_the_exact_amount_of_objects()
        {
            var pooledObject = new GameObject("pooled_object").AddComponent<PooledObject>();
            var objectPooling = new GameObject("object_pooling").AddComponent<ObjectPooling>();

            objectPooling.Setup(new ObjectPoolingSettings() {
                ObjectPrefab = pooledObject.gameObject,
                PoolSize = 3,
                CanGrown = false
            });

            objectPooling.InstantiateObjects();

            Assert.That(objectPooling.GetAvailableObject().IsPresent, Is.True);
            Assert.That(objectPooling.GetAvailableObject().IsPresent, Is.True);
            Assert.That(objectPooling.GetAvailableObject().IsPresent, Is.True);
            Assert.That(objectPooling.GetAvailableObject().IsPresent, Is.False);
        }

        [Test]
        public void Should_continues_instantiating_objects_where_can_grown_is_active()
        {
            var pooledObject = new GameObject("pooled_object").AddComponent<PooledObject>();
            var objectPooling = new GameObject("object_pooling").AddComponent<ObjectPooling>();

            objectPooling.Setup(new ObjectPoolingSettings() {
                ObjectPrefab = pooledObject.gameObject,
                PoolSize = 3,
                CanGrown = true
            });

            objectPooling.InstantiateObjects();

            Assert.That(objectPooling.GetAvailableObject().IsPresent, Is.True);
            Assert.That(objectPooling.GetAvailableObject().IsPresent, Is.True);
            Assert.That(objectPooling.GetAvailableObject().IsPresent, Is.True);
            Assert.That(objectPooling.GetAvailableObject().IsPresent, Is.True);
            Assert.That(objectPooling.GetAvailableObject().IsPresent, Is.True);
            Assert.That(objectPooling.GetAvailableObject().IsPresent, Is.True);
            Assert.That(objectPooling.GetAvailableObject().IsPresent, Is.True);
        }

        [Test]
        public void Should_remove_previous_listeners_when_object_is_activated()
        {
            var pooledObject = new GameObject("pooled_object").AddComponent<PooledObject>();
            var objectPooling = new GameObject("object_pooling").AddComponent<ObjectPooling>();

            objectPooling.Setup(new ObjectPoolingSettings() {
                ObjectPrefab = pooledObject.gameObject,
                PoolSize = 1,
                CanGrown = false
            });

            objectPooling.InstantiateObjects();

            var obj = objectPooling.GetAvailableObject().Get();
            var destroyEvent = new EventTest(obj, nameof(obj.OnDestroyAction));

            obj.Destroy();

            Assert.That(destroyEvent.WasTriggered, Is.True);
            Assert.That(destroyEvent.TriggerCount, Is.EqualTo(1));

            var newObj = objectPooling.GetAvailableObject().Get();
            newObj.Destroy();

            Assert.That(destroyEvent.TriggerCount, Is.EqualTo(1));
        }
    }
}
