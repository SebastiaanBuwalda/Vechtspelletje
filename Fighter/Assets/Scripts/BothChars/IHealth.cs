﻿using UnityEngine;
using System.Collections;

public interface IHealth{

    void ChangeHealth(int damage);
    void OnDeath();

}