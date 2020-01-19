using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

         
        InteractionType = E_InteractionObjects.Trigger;
    }
        Animation = InteractionObject.GetComponent<Animation>();
	}

    public override float DoInteraction(E_InteractionType type)
      //  Debug.Log(gameObject.name + " DoInteraction");

        OnInteractionStart();

        Animation.Play(Anim.name);        

        return Animation[Anim.name].length;
    }
        //Debug.Log(gameObject.name + " AnimationDone");

        OnInteractionEnd();


    public override void Restart()
    {
       // Debug.Log(gameObject.name + " restart");
        gameObject.SetActiveRecursively(true);
        Animation.Stop();
        Anim.SampleAnimation(InteractionObject, 0);

        base.Restart();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, (GetComponent<Collider>() as SphereCollider).radius);
    }
}