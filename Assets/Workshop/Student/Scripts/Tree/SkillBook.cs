using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


    public class SkillBook : MonoBehaviour
    {
        public SkillTree attackSkillTree;

        Skill attack;
        Skill fireStorm;
        Skill fireBall;
        Skill fireBlast;
        Skill fireWave;
        Skill fireExplosion;

        public void Start()
        {
        // build skill tree
        // └── Attack
        //     └── FireStorm
        //         ├── FireBlast
        //         └── FireBall
        //             └── FireWave
        //                 └── FireExplosion

        attack = new Skill("Attack");
        fireStorm = new Skill("FireStorm");
        fireBall = new Skill("FireBall");
        fireBlast = new Skill("FireBlast");
        fireWave = new Skill("FireWave");
        fireExplosion = new Skill("FireExplosion");

        // 1. set the nextSkills for each skill

        // [0] Attack -> FireStorm
        attack.nextSkills.Add(fireStorm);

        // [1] FireStorm -> FireBlast
        attack.nextSkills.Add(fireBlast);

        // [2] FireStorm -> FireBall
        attack.nextSkills.Add(fireBall);

        // [3] FireBall -> FireWave
        attack.nextSkills.Add(fireWave);

        // [4] FireWave -> FireExplosion
        attack.nextSkills.Add(fireExplosion);

        this.attackSkillTree = new SkillTree(attack);
        attack.isAvailable = true;
        }

        public void Update()
        {
            Keyboard keyboard = Keyboard.current;
            if (keyboard != null && keyboard.pKey.wasPressedThisFrame)
            {
                 attackSkillTree.rootSkill.PrintSkillTreeHierarchy("");
                // attackSkillTree.rootSkill.PrintSkillTree();
                Debug.Log("====================================");
            } 
        }
    }

