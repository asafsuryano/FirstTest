// Decompiled with JetBrains decompiler
// Type: VehiclePhysics.VehicleBase
// Assembly: VehiclePhysics, Version=7.0.7264.31677, Culture=neutral, PublicKeyToken=null
// MVID: BF795726-A0C5-40AB-B959-3B97B61C9CBB
// Assembly location: D:\Sdk\VehiclePhysics.dll
/*
using EdyCommonTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace VehiclePhysics
{
  [DisallowMultipleComponent]
  public abstract class VehicleBase : MonoBehaviour
  {
    public bool tireSideDeflection;
    public float tireSideDeflectionRate;
    [Range(0.0f, 1f)]
    public float tireImpulseRatio;
    [Range(0.0f, 1f)]
    public float wheelSleepVelocity;
    public bool advancedSuspensionDamper;
    public float suspensionDamperLimitFactor;
    public bool contactAngleAffectsTireForce;
    [Range(1f, 20f)]
    public int integrationSteps;
    public bool integrationUseRK4;
    public Transform centerOfMass;
    [HideInInspector]
    public bool accurateSuspensionForces;
    [HideInInspector]
    public float scaleFactor;
    [HideInInspector]
    public VehicleBase.VehicleSleepCriteria vehicleSleepCriteria;
    [NonSerialized]
    public bool inhibitWheelSleep;
    [NonSerialized]
    public bool invertVisualWheelSpinDirection;
    public Action onPreDynamicsStep;
    public Action onBeforeUpdateBlocks;
    public Action onBeforeIntegrationStep;
    public Action onPreVisualUpdate;
    private static Solver‏‪⁮‌‭‏⁫‭‍‭⁫‫‍‪⁯⁪⁬‫‌⁯‏‪‭⁭⁯​ = (Solver) null;
    private Wheel[] \u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮;
    private VehicleBase.WheelState[] \u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮;
    private Vector3 \u206C‌⁯​‪⁪⁪​​⁬‌​‌‭⁫‌‏⁬‮‮⁬⁪⁬‏​⁬‍‮⁬⁭‌‬‍⁫‪⁫⁪‍‪⁮‮;
    private Vector3 \u202B⁫⁯‍‎‪⁪‍⁪⁫‍⁬‭‮⁮⁬‌⁮‎⁪‏‮⁬‌⁫​‮‬⁫‍​‫⁭⁫‬⁪‌‫​⁯‮;
    private float \u200D‫⁭‭⁭⁭⁮⁮⁮‭⁯‫‫‬‮‬‭‮‬‍‮‬⁮‏‍‭‭‭⁯‪⁪‎‪‌⁮⁭⁭​⁫⁪‮;
    private float \u206F⁯⁮⁫⁮⁯⁭⁯⁭⁫‌‮‏​‏⁬​‭‍‏‪⁫‫‭‪⁮​‏⁬‏‪⁪‎⁭‫‌​‭⁬‮‮;
    public DataBus data;
    private Collider[] \u202D‭⁭⁬​​‫‌‬‌​​​‎​‭‌⁯⁯​‫⁯​‪‍⁫‍‎​‏⁮⁫⁬‌‫⁯⁬⁭‪‍‮;
    private int[] \u200F‬‮⁪⁬⁮‌‪‌‮‫⁮⁫⁭⁮⁬⁬⁮‫‮⁪‌⁯‏‫⁭⁮‭⁬⁯‭‍‎‫‎⁭‪⁬‏⁮‮;
    private bool \u200D⁫​‍‫​‏‫‮‪‭‏⁬⁮⁪⁫⁪⁫‪‍‌⁮⁬⁭‮‌‪‫‮‮⁮‭‫‭⁬‌‫‭⁬‮;
    private bool \u202C‬⁭⁮⁫‫‮‌⁪‬⁫‍‮​⁯‪‌⁪‮‎​‬⁫‏⁫‏​⁭‌‫⁬⁯‪⁫‌‏‮‌⁮‌‮;
    private bool \u206D⁭⁬‏‫⁭‏⁫⁬​⁪⁮‍‎⁭‫⁫‎‬‭‬⁫‪⁪​⁮‮‭‪⁭⁭⁭‪‫‍‏⁯‭‎⁯‮;
    private List<VehicleBehaviour> \u206B‫⁯⁭⁫‬⁪‮‪⁯⁭⁪⁫‪‮‍‫‭‮‏‌⁮‏⁭‬‪‏‬‫‭‪‌‍‍‮⁫⁬‪‫⁬‮;
    private static System.Type[] \u200C⁮⁭‌⁪‪⁮‮‌⁯‬‫⁮‭‪​‌‮‍⁫‭‌‎‏⁭‫‬‎‪‫‌⁮​⁬⁫‫⁮⁭‌‪‮ = new System.Type[11]
    {
      typeof (VPWheelCollider),
      typeof (VPStandardInput),
      typeof (VPTelemetry),
      typeof (VPVisualEffects),
      typeof (VPResetVehicle),
      typeof (VPRollingFriction),
      typeof (VPAeroSurface),
      typeof (VPAudio),
      typeof (VPAntiRollBar),
      typeof (VPForceCones),
      typeof (VPVehicleToolkit)
    };
    public bool showContactGizmos;
    [HideInInspector]
    public bool disableContactProcessing;
    public Action onImpact;
    public Action onRawCollision;
    public static VehicleBase vehicle = (VehicleBase) null;
    public static Collision currentCollision;
    public static bool isCollisionEnter;
    [NonSerialized]
    public float impactThreeshold;
    [NonSerialized]
    public float impactInterval;
    [NonSerialized]
    public float impactIntervalRandom;
    [NonSerialized]
    public float impactMinSpeed;
    private int \u206C⁫⁭‭‭⁭⁫⁭‬⁫‏⁮‎‪⁭⁫⁭⁯​‫⁭‍⁫⁪​‎‏‭​‮⁪⁫⁮⁯‮‍‌⁯⁮‍‮;
    private Vector3 \u200D​‎‪‪⁯‪​⁯⁬​⁬‪​‍⁭⁭‭‏​‏⁬‪‮⁪‌⁭⁭‫‬​⁭⁪⁮⁮‏‌⁮‫‎‮;
    private Vector3 \u206D‬⁪⁬⁯‭⁯⁯‬‏⁪‬​‫‫⁮‍⁮⁫‌‬‭‫‎‪⁪​⁪‮⁮‍⁭‍​‫‫‪‮‬⁮‮;
    private int \u202C‮‪​‬‮‍‮⁮‪‪⁬‪‬⁬‫⁬‮⁬⁬‏​‏⁭⁭⁯​⁯‏⁮‪⁭‭‮⁯‫‬⁬‍‏‮;
    private float \u206E‬‌‬‫​⁫​⁪‌‬⁬​‮‍‎⁯⁭⁭‫‫‮‭‭‫‬‎⁮‫‌​⁭‌⁯⁯‫⁪‪⁪‍‮;
    private Vector3 \u200F⁭⁫‍⁪‍⁭‬⁯⁭⁭‫‎​⁭⁬‌⁯⁫⁬‎‎⁮‍⁮⁯‏‏⁫‫‫‮‮⁯⁮‍‏⁪⁪⁯‮;
    private Vector3 \u206E⁬‏‪‪‮‭‌⁯⁭⁯⁪⁫⁫​‫‍⁯‫‌‫‭⁮‫‮‫⁭‏‮‮⁪⁮​⁬‏‪‬‮‍‎‮;
    private int \u200E‏‮⁯⁪⁮‍⁮‫‭‭‭⁫‬⁭⁪⁫⁫‬‮‌⁯‎‬‫​⁫⁪‌⁮‌‭⁯‬⁭‎‮‍‫⁪‮;
    private GroundMaterial \u202E‬⁮‭‪​⁬‭‭⁪⁯‎⁫‬‌⁭‏⁮‪⁮‏‎⁬⁭‍​⁫‪​⁭​‎‮‪‭⁭⁬‍‮⁭‮;
    private GroundMaterialHit \u200F‎‬‍‌‫‎‬⁮‮‬‭‫‍⁮⁬‭‮‎‮‪‏‌‏‌‮‏​‌⁫‬‫‏‬​⁯⁯‌‫‍‮;

    public Transform cachedTransform
    {
      get
      {
        if (!Object.op_Inequality((Object) this.\u200B‏‮‪⁬‪‮‏‫‫‍‏‌‏‪‏⁫⁯‮⁬‫⁪‎‍‭‫​⁯⁯⁫‎‌‏⁯‭⁯⁭‍‪‮‮, (Object) null))
        {
label_1:
          uint num;
          switch ((num = (uint) (453526575 ^ 45134156)) % 3U)
          {
            case 0:
              goto label_1;
            case 1:
              return ((Component) this).get_transform();
          }
        }
        return this.\u200B‏‮‪⁬‪‮‏‫‫‍‏‌‏‪‏⁫⁯‮⁬‫⁪‎‍‭‫​⁯⁯⁫‎‌‏⁯‭⁯⁭‍‪‮‮;
      }
    }

    public Rigidbody cachedRigidbody
    {
      get
      {
        if (!Object.op_Inequality((Object) this.\u206C‏‭⁮⁯‭‍‎‬⁫⁮⁮⁪‫​‏‪‎‏‫⁫⁪‫‫⁭⁮⁫⁯‪‍​‍⁮​‌⁫‏⁮⁪⁬‮, (Object) null))
        {
label_1:
          uint num;
          switch ((num = (uint) (783313298 ^ 1633986984)) % 3U)
          {
            case 1:
              return (Rigidbody) ((Component) this).GetComponentInParent<Rigidbody>();
            case 2:
              goto label_1;
          }
        }
        return this.\u206C‏‭⁮⁯‭‍‎‬⁫⁮⁮⁪‫​‏‪‎‏‫⁫⁪‫‫⁭⁮⁫⁯‪‍​‍⁮​‌⁫‏⁮⁪⁬‮;
      }
    }

    [DefaultValue(false)]
    public bool initialized { get; private set; }

    private GroundMaterialManagerBase groundMaterialManager { get; set; }

    public int wheelCount => this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮.Length;

    public VehicleBase.WheelState[] wheelState => this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮;

    public float speed => this.\u200D‫⁭‭⁭⁭⁮⁮⁮‭⁯‫‫‬‮‬‭‮‬‍‮‬⁮‏‍‭‭‭⁯‪⁪‎‪‌⁮⁭⁭​⁫⁪‮;

    public float speedAngle => this.\u206F⁯⁮⁫⁮⁯⁭⁯⁭⁫‌‮‏​‏⁬​‭‍‏‪⁫‫‭‪⁮​‏⁬‏‪⁪‎⁭‫‌​‭⁬‮‮;

    public Vector3 localAcceleration => this.\u206C‌⁯​‪⁪⁪​​⁬‌​‌‭⁫‌‏⁬‮‮⁬⁪⁬‏​⁬‍‮⁬⁭‌‬‍⁫‪⁫⁪‍‪⁮‮;

    public float time => this.\u200B​‫‏⁬⁬‌⁫⁪​⁯‪⁮​⁪‌⁪‫‌⁬⁭​‮⁮‮⁯‪‏‍‮‬‌‏⁪‍⁫⁮‪‍‪‮;

    public Vector3 GetWheelLocalPosition(VPWheelCollider wheelCol) => this.\u200B‏‮‪⁬‪‮‏‫‫‍‏‌‏‪‏⁫⁯‮⁬‫⁪‎‍‭‫​⁯⁯⁫‎‌‏⁯‭⁯⁭‍‪‮‮.InverseTransformPoint(wheelCol.cachedTransform.TransformPoint(wheelCol.center));

    public void NotifyCollidersChanged()
    {
      this.\u202D‭⁭⁬​​‫‌‬‌​​​‎​‭‌⁯⁯​‫⁯​‪‍⁫‍‎​‏⁮⁫⁬‌‫⁯⁬⁭‪‍‮ = ColliderUtility.GetSolidColliders(((Component) this).get_transform(), true);
      this.\u200F‬‮⁪⁬⁮‌‪‌‮‫⁮⁫⁭⁮⁬⁬⁮‫‮⁪‌⁯‏‫⁭⁮‭⁬⁯‭‍‎‫‎⁭‪⁬‏⁮‮ = new int[this.\u202D‭⁭⁬​​‫‌‬‌​​​‎​‭‌⁯⁯​‫⁯​‪‍⁫‍‎​‏⁮⁫⁬‌‫⁯⁬⁭‪‍‮.Length];
    }

    public bool paused
    {
      get => this.\u200D⁫​‍‫​‏‫‮‪‭‏⁬⁮⁪⁫⁪⁫‪‍‌⁮⁬⁭‮‌‪‫‮‮⁮‭‫‭⁬‌‫‭⁬‮;
      set
      {
        if (this.\u200D⁫​‍‫​‏‫‮‪‭‏⁬⁮⁪⁫⁪⁫‪‍‌⁮⁬⁭‮‌‪‫‮‮⁮‭‫‭⁬‌‫‭⁬‮ == value)
          return;
label_1:
        int num1 = 1762313494;
        while (true)
        {
          uint num2;
          switch ((num2 = (uint) (num1 ^ 251244898)) % 6U)
          {
            case 0:
              goto label_1;
            case 1:
              goto label_8;
            case 2:
              this.\u202C‬⁭⁮⁫‫‮‌⁪‬⁫‍‮​⁯‪‌⁪‮‎​‬⁫‏⁫‏​⁭‌‫⁬⁯‪⁫‌‏‮‌⁮‌‮ = false;
              this.\u206D⁭⁬‏‫⁭‏⁫⁬​⁪⁮‍‎⁭‫⁫‎‬‭‬⁫‪⁪​⁮‮‭‪⁭⁭⁭‪‫‍‏⁯‭‎⁯‮ = false;
              num1 = (int) num2 * 976941160 ^ 412301458;
              continue;
            case 3:
              this.\u202C⁫​⁫⁪‏‬‏⁬⁭⁫‭⁬⁮⁪⁫‮‫⁪‮‫‭‫⁯‭⁯‭⁫‏‭⁫​⁮⁪‮⁯‪‬⁫⁬‮();
              num1 = 1238188709;
              continue;
            case 4:
              this.\u200D⁫​‍‫​‏‫‮‪‭‏⁬⁮⁪⁫⁪⁫‪‍‌⁮⁬⁭‮‌‪‫‮‮⁮‭‫‭⁬‌‫‭⁬‮ = value;
              int num3 = !this.\u200D⁫​‍‫​‏‫‮‪‭‏⁬⁮⁪⁫⁪⁫‪‍‌⁮⁬⁭‮‌‪‫‮‮⁮‭‫‭⁬‌‫‭⁬‮ ? -902341891 : (num3 = -1158595889);
              num1 = num3 ^ (int) num2 * -131584040;
              continue;
            case 5:
              goto label_6;
            default:
              goto label_9;
          }
        }
label_8:
        return;
label_9:
        return;
label_6:
        this.\u202C‍‎⁭‪‫⁮⁭⁯‭⁬⁮⁬‌⁫⁮‪‪‍⁬‮⁯‪⁯‏​‏‍⁪⁪‫‏⁮‪‮⁯⁪‮‪⁭‮();
      }
    }

    public void SingleStep()
    {
      if (!this.paused)
        return;
label_1:
      int num1 = -1888060314;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -268257576)) % 6U)
        {
          case 0:
            this.\u202C‬⁭⁮⁫‫‮‌⁪‬⁫‍‮​⁯‪‌⁪‮‎​‬⁫‏⁫‏​⁭‌‫⁬⁯‪⁫‌‏‮‌⁮‌‮ = true;
            num1 = (int) num2 * -1340744488 ^ 1800885239;
            continue;
          case 1:
            goto label_8;
          case 2:
            int num3 = !this.\u202C‬⁭⁮⁫‫‮‌⁪‬⁫‍‮​⁯‪‌⁪‮‎​‬⁫‏⁫‏​⁭‌‫⁬⁯‪⁫‌‏‮‌⁮‌‮ ? 1211686604 : (num3 = 1517241589);
            num1 = num3 ^ (int) num2 * 1658951380;
            continue;
          case 3:
            goto label_1;
          case 4:
            int num4 = this.\u206D⁭⁬‏‫⁭‏⁫⁬​⁪⁮‍‎⁭‫⁫‎‬‭‬⁫‪⁪​⁮‮‭‪⁭⁭⁭‪‫‍‏⁯‭‎⁯‮ ? -577632779 : (num4 = -1785972070);
            num1 = num4 ^ (int) num2 * 1513686738;
            continue;
          case 5:
            this.\u206D⁭⁬‏‫⁭‏⁫⁬​⁪⁮‍‎⁭‫⁫‎‬‭‬⁫‪⁪​⁮‮‭‪⁭⁭⁭‪‫‍‏⁯‭‎⁯‮ = true;
            num1 = (int) num2 * -54424016 ^ 1603544701;
            continue;
          default:
            goto label_9;
        }
      }
label_8:
      return;
label_9:;
    }

    public void Reposition(Vector3 position, Quaternion rotation)
    {
      this.\u200B‏‮‪⁬‪‮‏‫‫‍‏‌‏‪‏⁫⁯‮⁬‫⁪‎‍‭‫​⁯⁯⁫‎‌‏⁯‭⁯⁭‍‪‮‮.set_position(position);
      this.\u200B‏‮‪⁬‪‮‏‫‫‍‏‌‏‪‏⁫⁯‮⁬‫⁪‎‍‭‫​⁯⁯⁫‎‌‏⁯‭⁯⁭‍‪‮‮.set_rotation(rotation);
      this.\u200B‭‌‭⁭⁪⁫‏‌‭⁬⁯⁯⁫⁫​⁮‏‍‌‍‍‫‌⁬⁯‏‭⁯​⁬‌‍⁬⁬‏‮‮‮‌‮();
    }

    public void SetWheelRadius(int wheelIndex, float radius)
    {
      if (wheelIndex < 0)
        return;
label_1:
      int num1 = 1689294940;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ 195754581)) % 6U)
        {
          case 0:
            goto label_1;
          case 1:
            int num3 = wheelIndex < this.wheels.Length ? -1906647716 : (num3 = -1302722411);
            num1 = num3 ^ (int) num2 * 722079184;
            continue;
          case 2:
            this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮[wheelIndex].wheelCol.radius = radius;
            num1 = (int) num2 * 1598027857 ^ 634679487;
            continue;
          case 3:
            radius = Mathf.Max(radius, 0.01f);
            num1 = (int) num2 * -100404341 ^ 1320720433;
            continue;
          case 4:
            goto label_8;
          case 5:
            this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮[wheelIndex].radius = radius;
            num1 = (int) num2 * -1686313587 ^ -1016574652;
            continue;
          default:
            goto label_9;
        }
      }
label_8:
      return;
label_9:;
    }

    public float GetWheelRadius(int wheelIndex)
    {
      if (wheelIndex >= 0)
      {
label_1:
        int num1 = 358947547;
        while (true)
        {
          uint num2;
          switch ((num2 = (uint) (num1 ^ 2053912586)) % 4U)
          {
            case 1:
              int num3 = wheelIndex < this.wheels.Length ? 2072113509 : (num3 = 487354690);
              num1 = num3 ^ (int) num2 * 1959527808;
              continue;
            case 2:
              goto label_1;
            case 3:
              goto label_4;
            default:
              goto label_5;
          }
        }
label_4:
        return this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮[wheelIndex].radius;
      }
label_5:
      return 0.0f;
    }

    public void SetWheelTireFriction(int wheelIndex, TireFriction friction)
    {
      if (wheelIndex < 0)
        return;
label_1:
      int num1 = 1728488127;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ 1629996155)) % 5U)
        {
          case 0:
            goto label_1;
          case 1:
            this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮[wheelIndex].tireFriction = friction;
            num1 = (int) num2 * 1377560865 ^ -1878877667;
            continue;
          case 2:
            int num3 = wheelIndex < this.wheels.Length ? 2085483697 : (num3 = 856975504);
            num1 = num3 ^ (int) num2 * -1090784925;
            continue;
          case 3:
            int num4 = friction == null ? -1592563896 : (num4 = -1893569458);
            num1 = num4 ^ (int) num2 * -756618578;
            continue;
          case 4:
            goto label_7;
          default:
            goto label_8;
        }
      }
label_7:
      return;
label_8:;
    }

    public void SetWheelTireFrictionMultiplier(int wheelIndex, float frictionMultiplier)
    {
      if (wheelIndex < 0)
        return;
label_1:
      int num1 = 1288260462;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ 2109628391)) % 4U)
        {
          case 0:
            goto label_1;
          case 1:
            int num3 = wheelIndex >= this.wheels.Length ? -844345085 : (num3 = -1186039190);
            num1 = num3 ^ (int) num2 * -56963694;
            continue;
          case 2:
            goto label_6;
          case 3:
            this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮[wheelIndex].tireFriction.frictionMultiplier = Mathf.Max(0.0f, frictionMultiplier);
            num1 = (int) num2 * 165894728 ^ -1698849511;
            continue;
          default:
            goto label_7;
        }
      }
label_6:
      return;
label_7:;
    }

    public TireFriction GetWheelTireFriction(int wheelIndex)
    {
      if (wheelIndex >= 0)
      {
label_1:
        int num1 = 1258198468;
        while (true)
        {
          uint num2;
          switch ((num2 = (uint) (num1 ^ 1921506254)) % 4U)
          {
            case 0:
              goto label_1;
            case 2:
              int num3 = wheelIndex >= this.wheels.Length ? 533226573 : (num3 = 934033207);
              num1 = num3 ^ (int) num2 * -1500534903;
              continue;
            case 3:
              goto label_4;
            default:
              goto label_5;
          }
        }
label_4:
        return this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮[wheelIndex].tireFriction;
      }
label_5:
      return (TireFriction) null;
    }

    public float GetWheelAngularVelocityForSlip(int wheelIndex, float slip)
    {
      if (wheelIndex >= 0)
      {
label_1:
        int num1 = 331312463;
        VehicleBase.WheelState wheelState;
        Wheel wheel;
        while (true)
        {
          uint num2;
          switch ((num2 = (uint) (num1 ^ 1551695968)) % 7U)
          {
            case 1:
              goto label_3;
            case 2:
              int num3 = !wheelState.grounded ? -812622487 : (num3 = -1259381131);
              num1 = num3 ^ (int) num2 * 862004391;
              continue;
            case 3:
              wheelState = this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮[wheelIndex];
              wheel = this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮[wheelIndex];
              num1 = 606397931;
              continue;
            case 4:
              goto label_1;
            case 5:
              int num4 = wheelIndex >= this.wheels.Length ? -996960997 : (num4 = -810586749);
              num1 = num4 ^ (int) num2 * -2087546587;
              continue;
            case 6:
              goto label_5;
            default:
              goto label_8;
          }
        }
label_3:
        return 0.0f;
label_8:
        return ((float) wheelState.localWheelVelocity.y + slip) / wheel.radius;
      }
label_5:
      return 0.0f;
    }

    public Vector2 GetWheelPeakSlip(int wheelIndex)
    {
      if (wheelIndex >= 0)
      {
label_1:
        int num1 = 1386556411;
        while (true)
        {
          uint num2;
          switch ((num2 = (uint) (num1 ^ 1514051818)) % 4U)
          {
            case 0:
              goto label_1;
            case 1:
              int num3 = wheelIndex < this.wheels.Length ? -1600828178 : (num3 = -1900461245);
              num1 = num3 ^ (int) num2 * -102747137;
              continue;
            case 2:
              goto label_4;
            default:
              goto label_5;
          }
        }
label_5:
        Wheel wheel = this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮[wheelIndex];
        return wheel.tireFriction.GetPeakSlipBounds(wheel.contactPatch);
      }
label_4:
      return Vector2.get_zero();
    }

    public Vector2 GetWheelAdherentSlip(int wheelIndex)
    {
      if (wheelIndex >= 0)
      {
label_1:
        int num1 = -2054594020;
        while (true)
        {
          uint num2;
          switch ((num2 = (uint) (num1 ^ -2112025625)) % 4U)
          {
            case 0:
              goto label_1;
            case 1:
              goto label_4;
            case 3:
              int num3 = wheelIndex < this.wheels.Length ? -1223576335 : (num3 = -1456341562);
              num1 = num3 ^ (int) num2 * -1545178852;
              continue;
            default:
              goto label_5;
          }
        }
label_5:
        Wheel wheel = this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮[wheelIndex];
        return wheel.tireFriction.GetAdherentSlipBounds(wheel.contactPatch);
      }
label_4:
      return Vector2.get_zero();
    }

    public void AddWheelBrakeTorque(int wheelIndex, float torque)
    {
      if (wheelIndex < 0)
        return;
label_1:
      int num1 = -1450437489;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -1002440610)) % 5U)
        {
          case 0:
            goto label_7;
          case 1:
            double num3 = (double) this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮[wheelIndex].AddBrakeTorque(torque);
            num1 = -1548619035;
            continue;
          case 2:
            goto label_6;
          case 3:
            int num4 = wheelIndex >= this.wheels.Length ? 373411679 : (num4 = 230396703);
            num1 = num4 ^ (int) num2 * 538122154;
            continue;
          case 4:
            goto label_1;
          default:
            goto label_8;
        }
      }
label_7:
      return;
label_6:
      return;
label_8:;
    }

    public VehicleBase.VehicleStateVars GetVehicleStateVars()
    {
      VehicleBase.VehicleStateVars vehicleStateVars = new VehicleBase.VehicleStateVars();
label_1:
      int num1 = 1517105261;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ 1088696237)) % 5U)
        {
          case 0:
            goto label_1;
          case 1:
            vehicleStateVars.time = this.\u200B​‫‏⁬⁬‌⁫⁪​⁯‪⁮​⁪‌⁪‫‌⁬⁭​‮⁮‮⁯‪‏‍‮‬‌‏⁪‍⁫⁮‪‍‪‮;
            num1 = (int) num2 * -85148370 ^ -2041142592;
            continue;
          case 2:
            vehicleStateVars.lastVelocity = this.\u202B⁫⁯‍‎‪⁪‍⁪⁫‍⁬‭‮⁮⁬‌⁮‎⁪‏‮⁬‌⁫​‮‬⁫‍​‫⁭⁫‬⁪‌‫​⁯‮;
            num1 = (int) num2 * -836350779 ^ -1446991341;
            continue;
          case 3:
            vehicleStateVars.lastImpactTime = this.\u206E‬‌‬‫​⁫​⁪‌‬⁬​‮‍‎⁯⁭⁭‫‫‮‭‭‫‬‎⁮‫‌​⁭‌⁯⁯‫⁪‪⁪‍‮;
            num1 = (int) num2 * 880983 ^ -518734493;
            continue;
          default:
            goto label_6;
        }
      }
label_6:
      return vehicleStateVars;
    }

    public void SetVehicleStateVars(VehicleBase.VehicleStateVars stateVars)
    {
      this.\u200B​‫‏⁬⁬‌⁫⁪​⁯‪⁮​⁪‌⁪‫‌⁬⁭​‮⁮‮⁯‪‏‍‮‬‌‏⁪‍⁫⁮‪‍‪‮ = stateVars.time;
label_1:
      int num1 = -826928345;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -1240051632)) % 3U)
        {
          case 1:
            this.\u202B⁫⁯‍‎‪⁪‍⁪⁫‍⁬‭‮⁮⁬‌⁮‎⁪‏‮⁬‌⁫​‮‬⁫‍​‫⁭⁫‬⁪‌‫​⁯‮ = stateVars.lastVelocity;
            num1 = (int) num2 * -981480137 ^ -382365063;
            continue;
          case 2:
            goto label_1;
          default:
            goto label_4;
        }
      }
label_4:
      this.\u206E‬‌‬‫​⁫​⁪‌‬⁬​‮‍‎⁯⁭⁭‫‫‮‭‭‫‬‎⁮‫‌​⁭‌⁯⁯‫⁪‪⁪‍‮ = stateVars.lastImpactTime;
    }

    public VehicleBase.WheelStateVars[] GetWheelStateVars()
    {
      VehicleBase.WheelStateVars[] wheelStateVarsArray = new VehicleBase.WheelStateVars[this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮.Length];
      int index = 0;
label_5:
      int num1 = index >= this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮.Length ? 1593427549 : (num1 = 1406471579);
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ 714343051)) % 5U)
        {
          case 1:
            ++index;
            num1 = (int) num2 * 1720585662 ^ -2141239993;
            continue;
          case 2:
            wheelStateVarsArray[index] = new VehicleBase.WheelStateVars()
            {
              L = this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮[index].L,
              Tr = this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮[index].Tr,
              contactDepth = this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮[index].contactDepth,
              lastTireForce = this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮[index].lastTireForce
            };
            num1 = 995837339;
            continue;
          case 3:
            num1 = 1406471579;
            continue;
          case 4:
            goto label_5;
          default:
            goto label_6;
        }
      }
label_6:
      return wheelStateVarsArray;
    }

    public void SetWheelStateVars(VehicleBase.WheelStateVars[] stateVars)
    {
      if (stateVars.Length == this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮.Length)
        goto label_9;
label_1:
      int num1 = 2018129861;
label_2:
      int index;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ 443900482)) % 10U)
        {
          case 0:
            this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮[index].reactionTorque = stateVars[index].Tr;
            num1 = (int) num2 * 1611283061 ^ 58354604;
            continue;
          case 1:
            goto label_3;
          case 2:
            ++index;
            num1 = (int) num2 * 556315560 ^ -1591747847;
            continue;
          case 3:
            this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮[index].lastTireForce = stateVars[index].lastTireForce;
            num1 = (int) num2 * -1876840863 ^ -777610277;
            continue;
          case 4:
            this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮[index].contactDepth = stateVars[index].contactDepth;
            num1 = (int) num2 * -346320035 ^ -1023086463;
            continue;
          case 5:
            int num3;
            num1 = num3 = index >= this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮.Length ? 1223587531 : (num3 = 364806010);
            continue;
          case 6:
            goto label_1;
          case 7:
            goto label_9;
          case 8:
            this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮[index].L = stateVars[index].L;
            this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮[index].Tr = stateVars[index].Tr;
            num1 = 907919024;
            continue;
          case 9:
            goto label_7;
          default:
            goto label_12;
        }
      }
label_3:
      return;
label_7:
      return;
label_12:
      return;
label_9:
      index = 0;
      num1 = 1241550665;
      goto label_2;
    }

    public VehicleBase.SolverState GetSolverState()
    {
      Block[] blockArray = VehicleBase.\u202E‏‪⁮‌‭‏⁫‭‍‭⁫‫‍‪⁯⁪⁬‫‌⁯‏‪‭⁭⁯​‌⁪‬‎‎‍​⁬‭‮‬‭⁭‮.GetBlockArray();
label_1:
      int num1 = -1247824285;
      Block.Connection connection;
      int index1;
      Block block;
      int index2;
      VehicleBase.SolverState solverState;
      VehicleBase.BlockState blockState1;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -109916742)) % 17U)
        {
          case 0:
            num1 = (int) num2 * -1910950230 ^ 1231610335;
            continue;
          case 1:
            VehicleBase.BlockState[] blockStates1 = solverState.blockStates;
            int index3 = index1;
            blockState1 = new VehicleBase.BlockState();
            blockState1.L = 0.0f;
            blockState1.I = 0.0f;
            blockState1.Tr = 0.0f;
            blockState1.Td = 0.0f;
            VehicleBase.BlockState blockState2 = blockState1;
            blockStates1[index3] = blockState2;
            num1 = -1964140747;
            continue;
          case 2:
            ++index1;
            num1 = (int) num2 * 1309529540 ^ -898453693;
            continue;
          case 3:
            num1 = (int) num2 * 1107792258 ^ 1006494299;
            continue;
          case 4:
            connection = (Block.Connection) null;
            num1 = (int) num2 * -490918270 ^ -706338492;
            continue;
          case 5:
            num1 = (int) num2 * -481836759 ^ 372585992;
            continue;
          case 7:
            solverState.step = 0;
            num1 = (int) num2 * -778042221 ^ -1711677833;
            continue;
          case 8:
            goto label_1;
          case 9:
            connection = block.inputs[index2];
            int num3;
            num1 = num3 = connection != null ? -1227196475 : (num3 = -1044715887);
            continue;
          case 10:
            int num4;
            num1 = num4 = index1 < blockArray.Length ? -2049827194 : (num4 = -1619246896);
            continue;
          case 11:
            block = blockArray[index1];
            int num5;
            num1 = num5 = block.connectedInputs <= 0 ? -922424559 : (num5 = -207041561);
            continue;
          case 12:
            solverState.time = Solver.time;
            solverState.blockStates = new VehicleBase.BlockState[blockArray.Length];
            index1 = 0;
            num1 = (int) num2 * -1080389170 ^ -1073074286;
            continue;
          case 13:
            int num6;
            num1 = num6 = index2 >= block.inputs.Length ? -1227196475 : (num6 = -933234715);
            continue;
          case 14:
            ++index1;
            num1 = -975565497;
            continue;
          case 15:
            index2 = 0;
            num1 = (int) num2 * -595557515 ^ -830194591;
            continue;
          case 16:
            VehicleBase.BlockState[] blockStates2 = solverState.blockStates;
            int index4 = index1;
            blockState1 = new VehicleBase.BlockState();
            blockState1.L = connection.L;
            blockState1.I = connection.I;
            blockState1.Tr = connection.Tr;
            blockState1.Td = connection.outTd;
            VehicleBase.BlockState blockState3 = blockState1;
            blockStates2[index4] = blockState3;
            num1 = -600972083;
            continue;
          default:
            goto label_18;
        }
      }
label_18:
      return solverState;
    }

    public System.Type[] GetSolverBlockTypes()
    {
      Block[] blockArray = VehicleBase.\u202E‏‪⁮‌‭‏⁫‭‍‭⁫‫‍‪⁯⁪⁬‫‌⁯‏‪‭⁭⁯​‌⁪‬‎‎‍​⁬‭‮‬‭⁭‮.GetBlockArray();
      System.Type[] typeArray = new System.Type[blockArray.Length];
      int index = 0;
label_1:
      int num1 = 450432439;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ 1470717084)) % 6U)
        {
          case 0:
            int num3;
            num1 = num3 = index >= blockArray.Length ? 1903063473 : (num3 = 1708242912);
            continue;
          case 1:
            num1 = (int) num2 * 1397180279 ^ -1167269745;
            continue;
          case 2:
            ++index;
            num1 = (int) num2 * 1971217131 ^ -152086890;
            continue;
          case 4:
            typeArray[index] = blockArray[index].GetType();
            num1 = 1729792048;
            continue;
          case 5:
            goto label_1;
          default:
            goto label_7;
        }
      }
label_7:
      return typeArray;
    }

    private void \u200C‬‮‫‬‌‎​‪‬⁭‮‮⁬‏‮‏‭‌‪⁫‌‮⁯‪‫‭‫‮‮⁯‌‭‏‎‫​‎⁪‮()
    {
      int index = 0;
      int length = this.\u202D‭⁭⁬​​‫‌‬‌​​​‎​‭‌⁯⁯​‫⁯​‪‍⁫‍‎​‏⁮⁫⁬‌‫⁯⁬⁭‪‍‮.Length;
label_1:
      int num1 = -1845770793;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -1039678856)) % 6U)
        {
          case 0:
            int num3;
            num1 = num3 = index < length ? -738192157 : (num3 = -430446158);
            continue;
          case 1:
            num1 = (int) num2 * 1018270473 ^ -1963445801;
            continue;
          case 2:
            ++index;
            num1 = (int) num2 * -1071471913 ^ 1888420404;
            continue;
          case 3:
            goto label_1;
          case 4:
            goto label_3;
          case 5:
            GameObject gameObject = ((Component) this.\u202D‭⁭⁬​​‫‌‬‌​​​‎​‭‌⁯⁯​‫⁯​‪‍⁫‍‎​‏⁮⁫⁬‌‫⁯⁬⁭‪‍‮[index]).get_gameObject();
            this.\u200F‬‮⁪⁬⁮‌‪‌‮‫⁮⁫⁭⁮⁬⁬⁮‫‮⁪‌⁯‏‫⁭⁮‭⁬⁯‭‍‎‫‎⁭‪⁬‏⁮‮[index] = gameObject.get_layer();
            gameObject.set_layer(2);
            num1 = -1836636764;
            continue;
          default:
            goto label_8;
        }
      }
label_3:
      return;
label_8:;
    }

    private void \u200B‎‭‪‍⁭‭⁬⁪‍‏‪⁯⁮‮‪⁭‎⁮⁪⁬⁭⁯⁯‪⁯⁮‏⁬‭⁪‮‏⁮⁫‬‍‌⁯⁪‮()
    {
      int index = 0;
      int length = this.\u202D‭⁭⁬​​‫‌‬‌​​​‎​‭‌⁯⁯​‫⁯​‪‍⁫‍‎​‏⁮⁫⁬‌‫⁯⁬⁭‪‍‮.Length;
label_1:
      int num1 = 1553309375;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ 1808293935)) % 5U)
        {
          case 0:
            ((Component) this.\u202D‭⁭⁬​​‫‌‬‌​​​‎​‭‌⁯⁯​‫⁯​‪‍⁫‍‎​‏⁮⁫⁬‌‫⁯⁬⁭‪‍‮[index]).get_gameObject().set_layer(this.\u200F‬‮⁪⁬⁮‌‪‌‮‫⁮⁫⁭⁮⁬⁬⁮‫‮⁪‌⁯‏‫⁭⁮‭⁬⁯‭‍‎‫‎⁭‪⁬‏⁮‮[index]);
            ++index;
            num1 = 1476866666;
            continue;
          case 1:
            num1 = (int) num2 * -798925669 ^ -1712073894;
            continue;
          case 2:
            goto label_1;
          case 3:
            goto label_3;
          case 4:
            int num3;
            num1 = num3 = index >= length ? 1096714774 : (num3 = 527337278);
            continue;
          default:
            goto label_7;
        }
      }
label_3:
      return;
label_7:;
    }

    private void \u206B‏‌‏⁪⁭‪​⁯⁫⁪⁯⁭‮⁯⁫‎‮‮‭‬‮‮‎⁯⁭‬‭‪‮‮⁭‪‌⁭‎‌‎‬‬‮()
    {
      Vector3 velocity = this.\u206C‏‭⁮⁯‭‍‎‬⁫⁮⁮⁪‫​‏‪‎‏‫⁫⁪‫‫⁭⁮⁫⁯‪‍​‍⁮​‌⁫‏⁮⁪⁬‮.get_velocity();
      Vector3 forward = this.\u200B‏‮‪⁬‪‮‏‫‫‍‏‌‏‪‏⁫⁯‮⁬‫⁪‎‍‭‫​⁯⁯⁫‎‌‏⁯‭⁯⁭‍‪‮‮.get_forward();
      this.\u200D‫⁭‭⁭⁭⁮⁮⁮‭⁯‫‫‬‮‬‭‮‬‍‮‬⁮‏‍‭‭‭⁯‪⁪‎‪‌⁮⁭⁭​⁫⁪‮ = Vector3.Dot(velocity, forward);
label_1:
      int num1 = -2097706239;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -1389598628)) % 5U)
        {
          case 0:
            forward.y = (__Null) 0.0;
            num1 = (int) num2 * -83102740 ^ 658798894;
            continue;
          case 1:
            velocity.y = (__Null) 0.0;
            num1 = (int) num2 * -1576554875 ^ -373909935;
            continue;
          case 2:
            goto label_1;
          case 3:
            goto label_3;
          case 4:
            this.\u206F⁯⁮⁫⁮⁯⁭⁯⁭⁫‌‮‏​‏⁬​‭‍‏‪⁫‫‭‪⁮​‏⁬‏‪⁪‎⁭‫‌​‭⁬‮‮ = Vector3.Angle(velocity, forward) * Mathf.Sign(Vector3.Dot(velocity, this.\u200B‏‮‪⁬‪‮‏‫‫‍‏‌‏‪‏⁫⁯‮⁬‫⁪‎‍‭‫​⁯⁯⁫‎‌‏⁯‭⁯⁭‍‪‮‮.get_right()));
            num1 = (int) num2 * 122915936 ^ 1068141265;
            continue;
          default:
            goto label_7;
        }
      }
label_3:
      return;
label_7:;
    }

    private void \u200B⁮‍​‪‭​‫‪‭‭‫⁬⁭⁪⁭‫‫⁮⁮‍‌‫‎⁫⁮‍‍‎‫‭​⁯‎‮‬‍‌⁪⁫‮()
    {
      Vector3 velocity = this.\u206C‏‭⁮⁯‭‍‎‬⁫⁮⁮⁪‫​‏‪‎‏‫⁫⁪‫‫⁭⁮⁫⁯‪‍​‍⁮​‌⁫‏⁮⁪⁬‮.get_velocity();
      this.\u206C‌⁯​‪⁪⁪​​⁬‌​‌‭⁫‌‏⁬‮‮⁬⁪⁬‏​⁬‍‮⁬⁭‌‬‍⁫‪⁫⁪‍‪⁮‮ = this.\u200B‏‮‪⁬‪‮‏‫‫‍‏‌‏‪‏⁫⁯‮⁬‫⁪‎‍‭‫​⁯⁯⁫‎‌‏⁯‭⁯⁭‍‪‮‮.InverseTransformDirection(Vector3.op_Division(Vector3.op_Subtraction(velocity, this.\u202B⁫⁯‍‎‪⁪‍⁪⁫‍⁬‭‮⁮⁬‌⁮‎⁪‏‮⁬‌⁫​‮‬⁫‍​‫⁭⁫‬⁪‌‫​⁯‮), Time.get_deltaTime()));
      this.\u202B⁫⁯‍‎‪⁪‍⁪⁫‍⁬‭‮⁮⁬‌⁮‎⁪‏‮⁬‌⁫​‮‬⁫‍​‫⁭⁫‬⁪‌‫​⁯‮ = velocity;
    }

    private void \u206A⁯‌⁯‮‍⁮​‮⁬‌⁬‮⁪⁮⁪⁮‏⁪‪⁮⁯⁭⁭‏⁭‏‏⁮‭⁬⁭‌‏‎⁮‬‬‌‫‮()
    {
      if (!Object.op_Inequality((Object) this.centerOfMass, (Object) null))
        return;
label_1:
      int num1 = -290868141;
      Vector3 vector3_1;
      Vector3 vector3_2;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -869679737)) % 5U)
        {
          case 0:
            goto label_1;
          case 1:
            goto label_7;
          case 2:
            this.\u206C‏‭⁮⁯‭‍‎‬⁫⁮⁮⁪‫​‏‪‎‏‫⁫⁪‫‫⁭⁮⁫⁯‪‍​‍⁮​‌⁫‏⁮⁪⁬‮.set_centerOfMass(vector3_1);
            num1 = (int) num2 * 1769501667 ^ -1246691483;
            continue;
          case 3:
            vector3_1 = this.\u200B‏‮‪⁬‪‮‏‫‫‍‏‌‏‪‏⁫⁯‮⁬‫⁪‎‍‭‫​⁯⁯⁫‎‌‏⁯‭⁯⁭‍‪‮‮.InverseTransformPoint(this.centerOfMass.get_position());
            vector3_2 = Vector3.op_Subtraction(this.\u206C‏‭⁮⁯‭‍‎‬⁫⁮⁮⁪‫​‏‪‎‏‫⁫⁪‫‫⁭⁮⁫⁯‪‍​‍⁮​‌⁫‏⁮⁪⁬‮.get_centerOfMass(), vector3_1);
            num1 = (int) num2 * 812184993 ^ 367545170;
            continue;
          case 4:
            int num3 = (double) ((Vector3) ref vector3_2).get_sqrMagnitude() > 1.0000000116861E-07 ? -162495740 : (num3 = -484652380);
            num1 = num3 ^ (int) num2 * -1402944308;
            continue;
          default:
            goto label_8;
        }
      }
label_7:
      return;
label_8:;
    }

    private static float \u202B​⁯‏⁯⁭⁬​⁬⁬⁫‌‌⁬‮⁭‪⁬⁮‪‮⁪‎‭⁯‭‌‪⁪‏‫​‫⁬⁫​‫‍‪‏‮(
      Vector2 _param0,
      Vector2 _param1)
    {
      float magnitude = ((Vector2) ref _param0).get_magnitude();
label_1:
      int num1 = -1790438913;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -1625804843)) % 4U)
        {
          case 0:
            goto label_1;
          case 2:
            int num3 = (double) magnitude <= 0.00999999977648258 ? -140283160 : (num3 = -485406298);
            num1 = num3 ^ (int) num2 * -854456026;
            continue;
          case 3:
            goto label_4;
          default:
            goto label_5;
        }
      }
label_4:
      double num4 = _param1.x * _param0.x / (double) magnitude;
      float y = (float) _param1.y;
      return Mathf.Sqrt((float) (num4 * num4 + (double) y * (double) y));
label_5:
      return ((Vector2) ref _param1).get_magnitude();
    }

    protected Wheel[] wheels => this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮;

    protected void SetNumberOfWheels(int numberOfWheels)
    {
      this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮ = new Wheel[4];
      this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮ = new VehicleBase.WheelState[4];
      if (numberOfWheels == 4)
        goto label_8;
label_1:
      int num1 = -619465873;
label_2:
      int index;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -1858259913)) % 10U)
        {
          case 0:
            this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮[index] = new Wheel();
            num1 = -1014469831;
            continue;
          case 1:
            goto label_5;
          case 2:
            this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮[index] = new VehicleBase.WheelState();
            this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮[index].lastGroundHit.physicMaterial = new PhysicMaterial();
            num1 = (int) num2 * 859941092 ^ 1589529501;
            continue;
          case 3:
            goto label_3;
          case 4:
            ++index;
            num1 = (int) num2 * 805000032 ^ 1395606024;
            continue;
          case 5:
            goto label_1;
          case 6:
            num1 = (int) num2 * 638762604 ^ -2130126216;
            continue;
          case 7:
            goto label_8;
          case 8:
            this.DebugLogError(\u003CModule\u003E.\u200D⁯‮​‮⁯⁮‏‬‮‌‏⁯‎‏‫⁮‭‬​‭⁭‏⁫⁫⁬‫‬‫‭‏​⁪‬‍​‫​⁯‍‮<string>(3775540379U));
            num1 = (int) num2 * -790551720 ^ -124253550;
            continue;
          case 9:
            int num3;
            num1 = num3 = index < numberOfWheels ? -919567373 : (num3 = -1252806510);
            continue;
          default:
            goto label_12;
        }
      }
label_3:
      return;
label_12:
      return;
label_5:
      ((Behaviour) this).set_enabled(false);
      return;
label_8:
      index = 0;
      num1 = -1975430541;
      goto label_2;
    }

    protected virtual void OnInitialize() => this.SetNumberOfWheels(4);

    protected virtual void OnFinalize()
    {
    }

    protected virtual void DoUpdateBlocks()
    {
    }

    protected virtual void DoUpdateData()
    {
    }

    protected virtual void OnUpdate()
    {
    }

    public virtual object GetInternalObject(System.Type type) => (object) null;

    public virtual int GetWheelIndex(int axle, VehicleBase.WheelPos position = VehicleBase.WheelPos.Default)
    {
      int num1 = (int) position;
      if (num1 >= 0)
        goto label_4;
label_1:
      int num2 = -1654649867;
label_2:
      int num3;
      while (true)
      {
        uint num4;
        switch ((num4 = (uint) (num2 ^ -18277134)) % 9U)
        {
          case 0:
            goto label_7;
          case 2:
            goto label_4;
          case 3:
            num1 = 1;
            num2 = (int) num4 * 76558075 ^ -996638172;
            continue;
          case 4:
            int num5 = num3 < 0 ? -1577593224 : (num5 = -53439369);
            num2 = num5 ^ (int) num4 * -1369900515;
            continue;
          case 5:
            num1 = 0;
            num2 = (int) num4 * 1192939940 ^ 1631119032;
            continue;
          case 6:
            goto label_1;
          case 7:
            int num6 = num3 < this.wheels.Length ? -301554866 : (num6 = -880951594);
            num2 = num6 ^ (int) num4 * -28644018;
            continue;
          case 8:
            num3 = axle * 2 + num1;
            num2 = -1698542230;
            continue;
          default:
            goto label_10;
        }
      }
label_7:
      return num3;
label_10:
      return -1;
label_4:
      num2 = num1 >= 2 ? -788240046 : (num2 = -1771204156);
      goto label_2;
    }

    public virtual int GetAxleCount() => this.wheels.Length / 2;

    public virtual int GetWheelsInAxle(int axle)
    {
      if (axle >= 0)
      {
label_1:
        int num1 = -647319691;
        while (true)
        {
          uint num2;
          switch ((num2 = (uint) (num1 ^ -1329832868)) % 4U)
          {
            case 0:
              goto label_4;
            case 1:
              int num3 = axle < this.GetAxleCount() ? 1375580836 : (num3 = 1610806054);
              num1 = num3 ^ (int) num2 * 530291592;
              continue;
            case 3:
              goto label_1;
            default:
              goto label_5;
          }
        }
label_4:
        return 2;
      }
label_5:
      return 0;
    }

    private void \u200E‌‪⁬‍⁮‌‮‪⁯⁫‫⁬‬‬⁮⁬‬‌‍⁯‪‬⁫‬‬‪⁮​‌‮‌⁪‍‫⁭‍‮‮‏‮(VehicleBase.WheelState _param1)
    {
      VPWheelCollider wheelCol = _param1.wheelCol;
label_1:
      int num1 = -1793827651;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -1904307372)) % 8U)
        {
          case 1:
            _param1.grounded = wheelCol.GetGroundHit(out _param1.hit);
            num1 = (int) num2 * -1767056804 ^ -2008638330;
            continue;
          case 2:
            _param1.contactDepth = wheelCol.GetContactDepth(((WheelHit) ref _param1.hit).get_point(), wheelCol.lastRuntimeSuspensionTravel);
            num1 = (int) num2 * -318727342 ^ -1705895324;
            continue;
          case 3:
            int num3 = !_param1.grounded ? 2133054843 : (num3 = 1870966652);
            num1 = num3 ^ (int) num2 * 857684878;
            continue;
          case 4:
            goto label_8;
          case 5:
            _param1.contactDepth = 0.0f;
            num1 = -233152332;
            continue;
          case 6:
            _param1.lastContactDepth = _param1.contactDepth;
            num1 = (int) num2 * 391771269 ^ -1716372327;
            continue;
          case 7:
            goto label_1;
          default:
            goto label_9;
        }
      }
label_8:
      _param1.suspensionCompression = _param1.contactDepth / wheelCol.lastRuntimeSuspensionTravel;
      return;
label_9:
      _param1.suspensionCompression = 0.0f;
      ((WheelHit) ref _param1.hit).set_force(0.0f);
    }

    private void \u206F⁫‏‭⁬‪⁭‎‍‏⁮⁯‬‍‮⁫‍⁭⁪‬⁭⁫‏⁭‏​‮‪⁮⁯‍‏⁪‏‫‭‎‭‭‏‮(VehicleBase.WheelState _param1)
    {
      VPWheelCollider wheelCol = _param1.wheelCol;
      if (!_param1.grounded)
        goto label_5;
label_1:
      int num1 = 1912001893;
label_2:
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ 1784882552)) % 12U)
        {
          case 0:
            wheelCol.SetSuspensionForceOffset(_param1.contactDepth);
            num1 = (int) num2 * -983978901 ^ -1528615809;
            continue;
          case 1:
            _param1.contactDepth += wheelCol.runtimeSuspensionTravel - wheelCol.lastRuntimeSuspensionTravel;
            _param1.suspensionCompression = _param1.contactDepth / wheelCol.runtimeSuspensionTravel;
            num1 = (int) num2 * -1439613132 ^ -700839760;
            continue;
          case 2:
            goto label_1;
          case 3:
            int num3;
            num1 = num3 = !this.accurateSuspensionForces ? 626531 : (num3 = 698160428);
            continue;
          case 4:
            _param1.contactSpeed = (_param1.contactDepth - _param1.lastContactDepth) / Time.get_deltaTime();
            num1 = (int) num2 * -931918912 ^ -1023566591;
            continue;
          case 5:
            _param1.damperForce = _param1.contactSpeed * wheelCol.runtimeDamperRate * this.scaleFactor;
            float num4 = (float) ((double) this.suspensionDamperLimitFactor * (double) this.\u206C‏‭⁮⁯‭‍‎‬⁫⁮⁮⁪‫​‏‪‎‏‫⁫⁪‫‫⁭⁮⁫⁯‪‍​‍⁮​‌⁫‏⁮⁪⁬‮.get_mass() * 9.80700016021729);
            _param1.damperForce = Mathf.Clamp(_param1.damperForce, -((WheelHit) ref _param1.hit).get_force(), num4);
            ref WheelHit local = ref _param1.hit;
            ((WheelHit) ref local).set_force(((WheelHit) ref local).get_force() + _param1.damperForce);
            num1 = (int) num2 * 2140714518 ^ -598490478;
            continue;
          case 6:
            goto label_5;
          case 7:
            goto label_3;
          case 8:
            num1 = (int) num2 * 515749861 ^ 1812934499;
            continue;
          case 9:
            int num5 = this.advancedSuspensionDamper ? 979028822 : (num5 = 1459294920);
            num1 = num5 ^ (int) num2 * -628214065;
            continue;
          case 10:
            num1 = (int) num2 * 580070789 ^ 1879523889;
            continue;
          case 11:
            _param1.damperForce = ((WheelHit) ref _param1.hit).get_force() - _param1.contactDepth * wheelCol.runtimeSpringRate * this.scaleFactor;
            num1 = 1232741998;
            continue;
          default:
            goto label_14;
        }
      }
label_3:
      return;
label_14:
      return;
label_5:
      _param1.contactSpeed = 0.0f;
      _param1.damperForce = 0.0f;
      num1 = 590101087;
      goto label_2;
    }

    private void \u206E⁮‮⁬‎⁬⁫​‬‫‫⁮‫⁪⁬‍⁫⁮⁬‎⁮‍⁮⁯⁯‬⁬​‎‮⁪⁫⁪⁪⁫‭‍‏⁮⁯‮(
      VehicleBase.WheelState _param1,
      float _param2)
    {
      if (!_param1.grounded)
        goto label_6;
label_1:
      int num1 = -276507633;
label_2:
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -2024758451)) % 10U)
        {
          case 1:
            _param1.downforce = 10f;
            num1 = (int) num2 * -100287923 ^ 496427238;
            continue;
          case 2:
            Vector3 up = _param1.wheelCol.cachedTransform.get_up();
            float num3 = Vector3.Dot(up, ((WheelHit) ref _param1.hit).get_sidewaysDir());
            float num4 = Vector3.Dot(up, ((WheelHit) ref _param1.hit).get_normal());
            _param1.contactAngle = Mathf.Atan2(num3, num4);
            num1 = (int) num2 * -1616391336 ^ -4858666;
            continue;
          case 3:
            _param1.downforce *= Mathf.Cos(_param1.contactAngle);
            num1 = (int) num2 * -549978729 ^ -1581119091;
            continue;
          case 4:
            goto label_6;
          case 5:
            goto label_1;
          case 6:
            _param1.downforce = ((WheelHit) ref _param1.hit).get_force() + _param1.wheelCol.runtimeExtraDownforce;
            num1 = (int) num2 * -564050455 ^ -107509484;
            continue;
          case 7:
            int num5;
            num1 = num5 = (double) _param1.downforce >= 10.0 ? -222670645 : (num5 = -1950392788);
            continue;
          case 8:
            goto label_10;
          case 9:
            int num6 = this.contactAngleAffectsTireForce ? -302192400 : (num6 = -1154905083);
            num1 = num6 ^ (int) num2 * 50566607;
            continue;
          default:
            goto label_11;
        }
      }
label_10:
      _param1.normalizedLoad = ((WheelHit) ref _param1.hit).get_force() / _param2;
      return;
label_11:
      _param1.normalizedLoad = 0.0f;
      return;
label_6:
      _param1.contactAngle = 0.0f;
      _param1.downforce = 0.0f;
      num1 = -959047683;
      goto label_2;
    }

    private void \u200B⁬⁯‪​⁭⁯‏‮⁭‎⁬‏⁭‎​‪⁭‫‬⁫​⁫⁫⁬‎‮‬⁪‫⁮⁬‮‎⁯⁬‎⁭‎⁮‮(VehicleBase.WheelState _param1)
    {
      if (_param1.grounded)
        goto label_25;
label_1:
      int num1 = 1405980198;
label_2:
      float num2;
      Vector2 vector2;
      float num3;
      float num4;
      GroundMaterialHit groundHit;
      GroundMaterialHit groundMaterialHit;
      while (true)
      {
        uint num5;
        switch ((num5 = (uint) (num1 ^ 1875450402)) % 31U)
        {
          case 0:
            goto label_1;
          case 1:
            num1 = (int) num5 * -367229832 ^ -1762911520;
            continue;
          case 2:
            Vector3 vector3 = Vector3.op_Division(Vector3.op_Multiply(Gravity.up, ((WheelHit) ref _param1.hit).get_force()), num4);
            _param1.surfaceForce = Vector3.op_Subtraction(vector3, Vector3.Project(vector3, ((WheelHit) ref _param1.hit).get_normal()));
            num1 = (int) num5 * 462213336 ^ 1603129340;
            continue;
          case 3:
            groundMaterialHit = new GroundMaterialHit();
            num1 = (int) num5 * 903891711 ^ 28200120;
            continue;
          case 4:
            _param1.externalTireForce = Vector2.op_Addition(vector2, _param1.localSurfaceForce);
            num1 = (int) num5 * -1489266427 ^ 1821545886;
            continue;
          case 5:
            vector2 = Vector2.op_Division(Vector2.op_Multiply(-this.tireImpulseRatio * num2, _param1.localWheelVelocity), Time.get_deltaTime());
            num1 = 40958719;
            continue;
          case 6:
            num2 = 0.0f;
            num1 = (int) num5 * 1526567640 ^ 433987425;
            continue;
          case 7:
            _param1.surfaceForce = Vector3.op_Multiply(Gravity.up, 100000f);
            num1 = 1916463121;
            continue;
          case 8:
            _param1.surfaceForce = Vector3.get_zero();
            num1 = (int) num5 * -1137326355 ^ 1491366859;
            continue;
          case 9:
            _param1.localWheelVelocity = Vector2.get_zero();
            num1 = (int) num5 * -1408748761 ^ 981432863;
            continue;
          case 10:
            int num6 = (double) num3 <= 0.0 ? -719138303 : (num6 = -1868622118);
            num1 = num6 ^ (int) num5 * 250989443;
            continue;
          case 11:
            int num7 = !Object.op_Inequality((Object) this.groundMaterialManager, (Object) null) ? 1710546126 : (num7 = 1797990204);
            num1 = num7 ^ (int) num5 * 1904093911;
            continue;
          case 12:
            goto label_3;
          case 13:
            int num8 = (double) num2 < 0.0 ? -1584775370 : (num8 = -1956225803);
            num1 = num8 ^ (int) num5 * -1045648346;
            continue;
          case 14:
            _param1.localSurfaceForce.x = (__Null) (double) Vector3.Dot(((WheelHit) ref _param1.hit).get_sidewaysDir(), _param1.surfaceForce);
            num1 = (int) num5 * -1067914581 ^ -1100180403;
            continue;
          case 15:
            num4 = Vector3.Dot(Gravity.up, ((WheelHit) ref _param1.hit).get_normal());
            int num9 = (double) num4 > 9.99999997475243E-07 ? 739199283 : (num9 = 1713073331);
            num1 = num9 ^ (int) num5 * 443493484;
            continue;
          case 16:
            this.groundMaterialManager.GetGroundMaterialCached(this, groundHit, ref _param1.lastGroundHit, ref _param1.groundMaterial);
            num1 = (int) num5 * -659947813 ^ -1389822220;
            continue;
          case 17:
            _param1.wheelVelocity = Vector3.get_zero();
            num1 = (int) num5 * -328570040 ^ -1075533420;
            continue;
          case 18:
            goto label_29;
          case 19:
            num3 = Mathf.InverseLerp(1f, 0.25f, ((Vector3) ref _param1.wheelVelocity).get_sqrMagnitude());
            num1 = (int) num5 * -1698296895 ^ -512931873;
            continue;
          case 20:
            _param1.localWheelVelocity.y = (__Null) (double) Vector3.Dot(((WheelHit) ref _param1.hit).get_forwardDir(), _param1.wheelVelocity);
            num1 = (int) num5 * 1156937610 ^ 2106032278;
            continue;
          case 21:
            _param1.surfaceForce = Vector3.get_zero();
            _param1.localSurfaceForce = Vector2.get_zero();
            num1 = 408139728;
            continue;
          case 22:
            num1 = (int) num5 * 1822816611 ^ 1651887331;
            continue;
          case 23:
            _param1.localSurfaceForce.y = (__Null) (double) Vector3.Dot(((WheelHit) ref _param1.hit).get_forwardDir(), _param1.surfaceForce);
            num1 = 1384437790;
            continue;
          case 24:
            goto label_25;
          case 25:
            num2 = (float) (((double) ((WheelHit) ref _param1.hit).get_force() + (double) _param1.wheelCol.runtimeExtraDownforce) * 0.101967982947826);
            num1 = 1591183468;
            continue;
          case 26:
            VehicleBase.WheelState wheelState = _param1;
            wheelState.localSurfaceForce = Vector2.op_Multiply(wheelState.localSurfaceForce, num3);
            num1 = (int) num5 * 620066483 ^ 1021598937;
            continue;
          case 27:
            _param1.localWheelVelocity.x = (__Null) (double) Vector3.Dot(((WheelHit) ref _param1.hit).get_sidewaysDir(), _param1.wheelVelocity);
            num1 = (int) num5 * 1282300201 ^ 761486552;
            continue;
          case 28:
            _param1.localSurfaceForce = Vector2.get_zero();
            _param1.externalTireForce = Vector2.get_zero();
            num1 = (int) num5 * 1993146285 ^ 2117881765;
            continue;
          case 29:
            groundHit = groundMaterialHit;
            num1 = (int) num5 * -1589555999 ^ -1188155140;
            continue;
          case 30:
            groundMaterialHit.physicMaterial = ((WheelHit) ref _param1.hit).get_collider().get_sharedMaterial();
            groundMaterialHit.collider = ((WheelHit) ref _param1.hit).get_collider();
            groundMaterialHit.hitPoint = ((WheelHit) ref _param1.hit).get_point();
            num1 = (int) num5 * -946766197 ^ -542521180;
            continue;
          default:
            goto label_33;
        }
      }
label_3:
      return;
label_29:
      return;
label_33:
      return;
label_25:
      _param1.wheelVelocity = _param1.wheelCol.GetTangentVelocity(((WheelHit) ref _param1.hit).get_point(), ((WheelHit) ref _param1.hit).get_normal(), ((WheelHit) ref _param1.hit).get_collider().get_attachedRigidbody());
      num1 = 72168261;
      goto label_2;
    }

    private void \u200F⁯‪‎‏⁬⁬⁪‌⁮‬‫‬‫⁪‮‭⁫⁬‪‫‍⁬​‍‮‫‬‎⁪⁬‌⁫‪‌‫‍‏‬⁪‮(VehicleBase.WheelState _param1)
    {
      if (_param1.grounded)
        goto label_13;
label_1:
      int num1 = 340753887;
label_2:
      Vector2 vector2;
      while (true)
      {
        uint num2;
        Vector3 vector3_1;
        Vector3 vector3_2;
        Vector3 vector3_3;
        switch ((num2 = (uint) (num1 ^ 959107884)) % 11U)
        {
          case 0:
            goto label_1;
          case 1:
            vector3_1 = Vector3.op_Addition(Vector3.op_Multiply(((WheelHit) ref _param1.hit).get_forwardDir(), (float) (_param1.tireForce.y + vector2.y)), Vector3.op_Multiply(((WheelHit) ref _param1.hit).get_sidewaysDir(), (float) (_param1.tireForce.x + vector2.x)));
            if (!this.advancedSuspensionDamper)
            {
              num1 = (int) num2 * -1068148773 ^ 299157964;
              continue;
            }
            vector3_3 = Vector3.op_Multiply(((Component) _param1.wheelCol).get_transform().get_up(), _param1.damperForce);
            break;
          case 2:
            goto label_16;
          case 3:
            goto label_3;
          case 4:
            _param1.wheelCol.ApplyForce(Vector3.op_Addition(vector3_1, vector3_2), ((WheelHit) ref _param1.hit).get_point(), ((WheelHit) ref _param1.hit).get_collider().get_attachedRigidbody());
            num1 = (int) num2 * 830744136 ^ 1753239673;
            continue;
          case 5:
            vector3_3 = Vector3.get_zero();
            break;
          case 6:
            _param1.tireForce.x = (__Null) (double) Mathf.Lerp((float) _param1.lastTireForce.x, (float) _param1.tireForce.x, this.tireSideDeflectionRate * Time.get_deltaTime());
            num1 = (int) num2 * -143067263 ^ -1084905071;
            continue;
          case 7:
            _param1.lastTireForce = Vector2.get_zero();
            num1 = (int) num2 * -544828148 ^ -820870916;
            continue;
          case 8:
            goto label_13;
          case 9:
            goto label_10;
          case 10:
            _param1.lastTireForce = _param1.tireForce;
            num1 = 2007745751;
            continue;
          default:
            goto label_19;
        }
        vector3_2 = vector3_3;
        num1 = 250156410;
      }
label_16:
      return;
label_3:
      return;
label_19:
      return;
label_10:
      double num3 = 0.0;
label_12:
      float num4 = (float) num3;
      vector2 = Vector2.op_Multiply((float) -((double) ((WheelHit) ref _param1.hit).get_force() * (double) ((Vector2) ref _param1.localWheelVelocity).get_magnitude() * (double) num4 * (1.0 / 1000.0)), _param1.localWheelVelocity);
      num1 = !this.tireSideDeflection ? 10735382 : (num1 = 170029355);
      goto label_2;
label_13:
      if (_param1.groundMaterial != null)
      {
        num3 = (double) _param1.groundMaterial.drag;
        goto label_12;
      }
      else
      {
        num1 = 1965246123;
        goto label_2;
      }
    }

    private void OnEnable()
    {
      this.\u200B‏‮‪⁬‪‮‏‫‫‍‏‌‏‪‏⁫⁯‮⁬‫⁪‎‍‭‫​⁯⁯⁫‎‌‏⁯‭⁯⁭‍‪‮‮ = (Transform) ((Component) this).GetComponent<Transform>();
label_1:
      int num1 = -1179463633;
      int index;
      int length;
      Vector3 centerOfMass;
      Wheel wheel;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -536964012)) % 50U)
        {
          case 0:
            int num3 = VehicleBase.\u202E‏‪⁮‌‭‏⁫‭‍‭⁫‫‍‪⁯⁪⁬‫‌⁯‏‪‭⁭⁯​‌⁪‬‎‎‍​⁬‭‮‬‭⁭‮ != null ? -39911270 : (num3 = -1086440995);
            num1 = num3 ^ (int) num2 * 1876426166;
            continue;
          case 1:
            this.\u206C‏‭⁮⁯‭‍‎‬⁫⁮⁮⁪‫​‏‪‎‏‫⁫⁪‫‫⁭⁮⁫⁯‪‍​‍⁮​‌⁫‏⁮⁪⁬‮.set_maxAngularVelocity(14f);
            this.NotifyCollidersChanged();
            num1 = -244582806;
            continue;
          case 2:
            this.DebugLogError(\u003CModule\u003E.\u200C‫⁪⁬‪‫‍‫⁪‫⁮‍⁮⁮‍⁮‮‏⁪⁭‭⁫‭‬⁪⁪⁬‮‍‍⁫‎‌‪⁮‭⁯⁪​⁯‮<string>(2958377953U));
            Solver solver = VehicleBase.\u202E‏‪⁮‌‭‏⁫‭‍‭⁫‫‍‪⁯⁪⁬‫‌⁯‏‪‭⁭⁯​‌⁪‬‎‎‍​⁬‭‮‬‭⁭‮;
            ((Component) this).get_gameObject().SetActive(false);
            VehicleBase.\u202E‏‪⁮‌‭‏⁫‭‍‭⁫‫‍‪⁯⁪⁬‫‌⁯‏‪‭⁭⁯​‌⁪‬‎‎‍​⁬‭‮‬‭⁭‮ = solver;
            num1 = (int) num2 * -1590372257 ^ 771683726;
            continue;
          case 3:
            this.\u206C‏‭⁮⁯‭‍‎‬⁫⁮⁮⁪‫​‏‪‎‏‫⁫⁪‫‫⁭⁮⁫⁯‪‍​‍⁮​‌⁫‏⁮⁪⁬‮.set_centerOfMass(centerOfMass);
            num1 = -866106051;
            continue;
          case 4:
            goto label_3;
          case 5:
            goto label_41;
          case 6:
            goto label_45;
          case 7:
            goto label_22;
          case 8:
            ((Behaviour) this).set_enabled(false);
            num1 = (int) num2 * -1727652076 ^ -1487272055;
            continue;
          case 9:
            goto label_31;
          case 10:
            goto label_4;
          case 11:
            VehicleBase.WheelState wheelState = this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮[index];
            wheel = this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮[index];
            int num4;
            num1 = num4 = !Object.op_Equality((Object) wheelState.wheelCol, (Object) null) ? -1333419877 : (num4 = -1078919902);
            continue;
          case 12:
            goto label_37;
          case 13:
            VehicleBase.\u202E‏‪⁮‌‭‏⁫‭‍‭⁫‫‍‪⁯⁪⁬‫‌⁯‏‪‭⁭⁯​‌⁪‬‎‎‍​⁬‭‮‬‭⁭‮ = new Solver();
            num1 = -45958553;
            continue;
          case 14:
            goto label_1;
          case 15:
            int num5;
            num1 = num5 = (double) wheel.radius >= 0.00999999977648258 ? -1925152617 : (num5 = -746288432);
            continue;
          case 16:
            index = 0;
            length = this.wheels.Length;
            num1 = (int) num2 * 340539689 ^ 1863727518;
            continue;
          case 17:
            int num6 = (double) wheel.mass >= 0.00999999977648258 ? 488421034 : (num6 = 1700521817);
            num1 = num6 ^ (int) num2 * 621158339;
            continue;
          case 18:
            this.\u206C‏‭⁮⁯‭‍‎‬⁫⁮⁮⁪‫​‏‪‎‏‫⁫⁪‫‫⁭⁮⁫⁯‪‍​‍⁮​‌⁫‏⁮⁪⁬‮.set_centerOfMass(this.\u200B‏‮‪⁬‪‮‏‫‫‍‏‌‏‪‏⁫⁯‮⁬‫⁪‎‍‭‫​⁯⁯⁫‎‌‏⁯‭⁯⁭‍‪‮‮.InverseTransformPoint(this.centerOfMass.get_position()));
            num1 = (int) num2 * 1484005277 ^ -1642260353;
            continue;
          case 19:
            this.OnInitialize();
            num1 = (int) num2 * -230804831 ^ 23885229;
            continue;
          case 20:
            this.DebugLogError(\u003CModule\u003E.\u200C‭⁫‪‍⁯‬‮​⁮‌⁫‫‏⁭⁬‪‬‌‪‍⁪⁪‍‮⁭‍‌‭‎​‭⁭​‏‬‮‭⁯⁯‮<string>(850795240U));
            num1 = -273580117;
            continue;
          case 21:
            int num7;
            num1 = num7 = this is VPVehicleController ? -205859143 : (num7 = -1669401937);
            continue;
          case 22:
            int num8;
            num1 = num8 = index >= length ? -81201635 : (num8 = -881104661);
            continue;
          case 23:
            int num9;
            num1 = num9 = wheel.tireFriction != null ? -147059639 : (num9 = -703923349);
            continue;
          case 24:
            int num10 = !Application.get_isConsolePlatform() ? -2121742799 : (num10 = -1265240640);
            num1 = num10 ^ (int) num2 * 40439;
            continue;
          case 25:
            VehicleBase.\u202E‏‪⁮‌‭‏⁫‭‍‭⁫‫‍‪⁯⁪⁬‫‌⁯‏‪‭⁭⁯​‌⁪‬‎‎‍​⁬‭‮‬‭⁭‮.Integrate(this.\u200B​‫‏⁬⁬‌⁫⁪​⁯‪⁮​⁪‌⁪‫‌⁬⁭​‮⁮‮⁯‪‏‍‮‬‌‏⁪‍⁫⁮‪‍‪‮, Time.get_fixedDeltaTime(), 1, false);
            this.\u206C‍‏⁫⁭‭⁪​⁯‏‫‬‎⁪‬⁪⁯​‫⁯⁪‎‏⁬⁭⁫‍⁮‍‮⁭⁪⁪‏‪⁪‍⁪‏⁫‮();
            this.initialized = true;
            num1 = -163506771;
            continue;
          case 26:
            VPWheelCollider.scaleFactor = this.scaleFactor;
            num1 = (int) num2 * -388752604 ^ 8651197;
            continue;
          case 27:
            goto label_17;
          case 28:
            centerOfMass = this.\u206C‏‭⁮⁯‭‍‎‬⁫⁮⁮⁪‫​‏‪‎‏‫⁫⁪‫‫⁭⁮⁫⁯‪‍​‍⁮​‌⁫‏⁮⁪⁬‮.get_centerOfMass();
            this.\u200B​‫‏⁬⁬‌⁫⁪​⁯‪⁮​⁪‌⁪‫‌⁬⁭​‮⁮‮⁯‪‏‍‮‬‌‏⁪‍⁫⁮‪‍‪‮ = 0.0f;
            num1 = -1623573638;
            continue;
          case 29:
            ((Component) this).get_gameObject().SetActive(false);
            num1 = (int) num2 * -1207473225 ^ 966284837;
            continue;
          case 30:
            int num11;
            num1 = num11 = !Application.get_isMobilePlatform() ? -1191702144 : (num11 = -741616052);
            continue;
          case 31:
            int num12 = Application.get_platform() != 16 ? 682427864 : (num12 = 1006526790);
            num1 = num12 ^ (int) num2 * -628435012;
            continue;
          case 32:
            int num13 = Object.op_Equality((Object) this.\u206C‏‭⁮⁯‭‍‎‬⁫⁮⁮⁪‫​‏‪‎‏‫⁫⁪‫‫⁭⁮⁫⁯‪‍​‍⁮​‌⁫‏⁮⁪⁬‮, (Object) null) ? -1427222137 : (num13 = -1301218770);
            num1 = num13 ^ (int) num2 * -1314447594;
            continue;
          case 33:
            int num14 = Application.get_platform() == null ? 499238092 : (num14 = 1956320289);
            num1 = num14 ^ (int) num2 * -2088877506;
            continue;
          case 34:
            this.DebugLogWarning(\u003CModule\u003E.\u200C‭⁫‪‍⁯‬‮​⁮‌⁫‫‏⁭⁬‪‬‌‪‍⁪⁪‍‮⁭‍‌‭‎​‭⁭​‏‬‮‭⁯⁯‮<string>(3332255738U) + VehicleBase.\u202E‏‪⁮‌‭‏⁫‭‍‭⁫‫‍‪⁯⁪⁬‫‌⁯‏‪‭⁭⁯​‌⁪‬‎‎‍​⁬‭‮‬‭⁭‮.resultMessage);
            num1 = (int) num2 * 1316415421 ^ 87067873;
            continue;
          case 35:
            int num15;
            num1 = num15 = Application.get_platform() != 2 ? -572528686 : (num15 = -1063734574);
            continue;
          case 36:
            wheel.RecalculateVars();
            ++index;
            num1 = (int) num2 * -1538963843 ^ -190214046;
            continue;
          case 37:
            int num16 = Application.get_platform() == 7 ? -2118626530 : (num16 = -1338700407);
            num1 = num16 ^ (int) num2 * -674076092;
            continue;
          case 38:
            num1 = (int) num2 * 1815313052 ^ -2098687262;
            continue;
          case 39:
            int num17 = VehicleBase.\u202E‏‪⁮‌‭‏⁫‭‍‭⁫‫‍‪⁯⁪⁬‫‌⁯‏‪‭⁭⁯​‌⁪‬‎‎‍​⁬‭‮‬‭⁭‮.Initialize(this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮, true) ? -1526115682 : (num17 = -19313981);
            num1 = num17 ^ (int) num2 * 1498416747;
            continue;
          case 40:
            this.groundMaterialManager = (GroundMaterialManagerBase) null;
            num1 = (int) num2 * -551855830 ^ -686443966;
            continue;
          case 41:
            int num18 = Object.op_Inequality((Object) this.centerOfMass, (Object) null) ? -388257956 : (num18 = -529954415);
            num1 = num18 ^ (int) num2 * 2131473298;
            continue;
          case 42:
            this.DebugLogError(\u003CModule\u003E.\u206A‮‭‮‫⁬‪‏‬⁮‪‮‬‬⁬‏⁮‮⁪⁪⁯⁯‭‫‮⁫⁭‏‫‫⁭‍‮‍⁯​⁯‍​‏‮<string>(240330153U) + (object) index + \u003CModule\u003E.\u200C‭⁫‪‍⁯‬‮​⁮‌⁫‫‏⁭⁬‪‬‌‪‍⁪⁪‍‮⁭‍‌‭‎​‭⁭​‏‬‮‭⁯⁯‮<string>(1842693982U));
            num1 = (int) num2 * -158319478 ^ -141178870;
            continue;
          case 43:
            this.DebugLogError(\u003CModule\u003E.\u200C‭⁫‪‍⁯‬‮​⁮‌⁫‫‏⁭⁬‪‬‌‪‍⁪⁪‍‮⁭‍‌‭‎​‭⁭​‏‬‮‭⁯⁯‮<string>(3866618698U));
            num1 = (int) num2 * 182739780 ^ -578768453;
            continue;
          case 44:
            int num19 = Application.get_platform() == 1 ? 1685751126 : (num19 = 2009206630);
            num1 = num19 ^ (int) num2 * 1187182358;
            continue;
          case 45:
            wheel.RecalculateConstants();
            num1 = -535874044;
            continue;
          case 46:
            this.DebugLogError(\u003CModule\u003E.\u206A‮‭‮‫⁬‪‏‬⁮‪‮‬‬⁬‏⁮‮⁪⁪⁯⁯‭‫‮⁫⁭‏‫‫⁭‍‮‍⁯​⁯‍​‏‮<string>(2765145217U) + (object) index + \u003CModule\u003E.\u200C‭⁫‪‍⁯‬‮​⁮‌⁫‫‏⁭⁬‪‬‌‪‍⁪⁪‍‮⁭‍‌‭‎​‭⁭​‏‬‮‭⁯⁯‮<string>(1842693982U));
            num1 = -2063950510;
            continue;
          case 47:
            this.DebugLogError(\u003CModule\u003E.\u206A‮‭‮‫⁬‪‏‬⁮‪‮‬‬⁬‏⁮‮⁪⁪⁯⁯‭‫‮⁫⁭‏‫‫⁭‍‮‍⁯​⁯‍​‏‮<string>(501156721U));
            num1 = (int) num2 * 516725573 ^ -281114195;
            continue;
          case 48:
            int num20 = Application.get_platform() == 13 ? 847313996 : (num20 = 1574069769);
            num1 = num20 ^ (int) num2 * -633189091;
            continue;
          case 49:
            this.\u206C‏‭⁮⁯‭‍‎‬⁫⁮⁮⁪‫​‏‪‎‏‫⁫⁪‫‫⁭⁮⁫⁯‪‍​‍⁮​‌⁫‏⁮⁪⁬‮ = (Rigidbody) ((Component) this).GetComponentInParent<Rigidbody>();
            num1 = (int) num2 * 257298315 ^ -1110160575;
            continue;
          default:
            goto label_52;
        }
      }
label_3:
      return;
label_41:
      return;
label_31:
      return;
label_37:
      return;
label_52:
      return;
label_4:
      ((Behaviour) this).set_enabled(false);
      return;
label_17:
      ((Component) this).get_gameObject().SetActive(false);
      return;
label_22:
      this.DebugLogError(\u003CModule\u003E.\u200D⁯‮​‮⁯⁮‏‬‮‌‏⁯‎‏‫⁮‭‬​‭⁭‏⁫⁫⁬‫‬‫‭‏​⁪‬‍​‫​⁯‍‮<string>(303047027U) + (object) index + \u003CModule\u003E.\u206E⁪‏‌⁮⁭‏‏⁭⁯​​⁪‏‪‫‭⁪⁮​‭‮⁮​‫⁯‍​‎⁯‪‏‏​⁫‬‮‪⁭⁮‮<string>(1049330751U));
      ((Behaviour) this).set_enabled(false);
      return;
label_45:
      ((Behaviour) this).set_enabled(false);
    }

    private void OnDisable()
    {
      if (!Object.op_Equality((Object) this.\u206C‏‭⁮⁯‭‍‎‬⁫⁮⁮⁪‫​‏‪‎‏‫⁫⁪‫‫⁭⁮⁫⁯‪‍​‍⁮​‌⁫‏⁮⁪⁬‮, (Object) null))
        goto label_5;
label_1:
      int num1 = 314313868;
label_2:
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ 779637675)) % 8U)
        {
          case 0:
            this.OnFinalize();
            VehicleBase.\u202E‏‪⁮‌‭‏⁫‭‍‭⁫‫‍‪⁯⁪⁬‫‌⁯‏‪‭⁭⁯​‌⁪‬‎‎‍​⁬‭‮‬‭⁭‮ = (Solver) null;
            num1 = (int) num2 * -678205976 ^ -557425778;
            continue;
          case 1:
            this.\u206C⁮‎‌⁫‌⁪‍‏‍‌⁪‮‫‭⁭‮⁮‭‌‌‌‭⁫⁯‬‮‪⁪⁫‫⁪‫‏⁬‬⁬⁯⁬⁯‮();
            num1 = (int) num2 * -158327759 ^ 1140212960;
            continue;
          case 2:
            this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮ = new Wheel[0];
            this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮ = new VehicleBase.WheelState[0];
            num1 = (int) num2 * 2128095111 ^ 1579810093;
            continue;
          case 3:
            this.initialized = false;
            num1 = (int) num2 * -727046775 ^ 249730217;
            continue;
          case 4:
            goto label_5;
          case 5:
            goto label_4;
          case 6:
            goto label_1;
          case 7:
            goto label_3;
          default:
            goto label_10;
        }
      }
label_4:
      return;
label_3:
      return;
label_10:
      return;
label_5:
      this.\u200C‪‍⁮⁬⁪‪​​⁭⁪‍​⁫‫⁭⁬⁭‍​⁭⁪‌‏‍‬⁭⁪‮‪⁫⁫‫‭‮⁬‎⁯‍‮();
      num1 = 268044832;
      goto label_2;
    }

    private void FixedUpdate()
    {
      Vector3 velocity = this.\u206C‏‭⁮⁯‭‍‎‬⁫⁮⁮⁪‫​‏‪‎‏‫⁫⁪‫‫⁭⁮⁫⁯‪‍​‍⁮​‌⁫‏⁮⁪⁬‮.get_velocity();
label_1:
      int num1 = -1816750721;
      while (true)
      {
        uint num2;
        int num3;
        float magnitude;
        int index1;
        VehicleBase.WheelState wheelState1;
        bool flag1;
        VehicleBase.WheelState wheelState2;
        int index2;
        int length1;
        VehicleBase.WheelState[] wheelStateArray;
        int index3;
        VehicleBase.WheelState wheelState3;
        Wheel wheel1;
        Wheel wheel2;
        float num4;
        int index4;
        VehicleBase.WheelState wheelState4;
        float num5;
        int length2;
        bool flag2;
        int length3;
        float num6;
        int num7;
        switch ((num2 = (uint) (num1 ^ -626678702)) % 72U)
        {
          case 0:
            wheelState2 = wheelStateArray[index4];
            num1 = -1786009216;
            continue;
          case 1:
            this.\u200B⁬⁯‪​⁭⁯‏‮⁭‎⁬‏⁭‎​‪⁭‫‬⁫​⁫⁫⁬‎‮‬⁪‫⁮⁬‮‎⁯⁬‎⁭‎⁮‮(wheelState4);
            num1 = (int) num2 * -583159126 ^ -480806420;
            continue;
          case 2:
            index1 = 0;
            length3 = this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮.Length;
            num1 = (int) num2 * -1270775991 ^ -927866191;
            continue;
          case 3:
            num6 = 1f / this.scaleFactor;
            num1 = (int) num2 * -1732105336 ^ -722510673;
            continue;
          case 4:
            wheelState3.tireSlip.x = wheelState3.localWheelVelocity.x;
            num1 = (int) num2 * 1312475555 ^ 1118262715;
            continue;
          case 5:
            this.\u200D‌‪‭⁫⁭⁮‬‮‫‎⁯‫‭⁭⁪‫⁯⁯‬‪⁯‬‭‏‮‭‭‫‌​‪‫‬‮‎⁮⁮⁪⁪‮();
            num1 = (int) num2 * 1290904257 ^ 1693083084;
            continue;
          case 6:
            wheelStateArray = this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮;
            num1 = (int) num2 * -1694936477 ^ 511572611;
            continue;
          case 7:
            int num8;
            num1 = num8 = this.onPreDynamicsStep != null ? -949999046 : (num8 = -493017948);
            continue;
          case 8:
            wheelState1 = this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮[index1];
            num1 = (int) num2 * 1613132482 ^ 62219520;
            continue;
          case 9:
            goto label_3;
          case 10:
            wheel2.Tr = Mathf.Clamp(wheelState1.reactionTorque, -num4, num4);
            num1 = (int) num2 * -513163626 ^ -552950470;
            continue;
          case 11:
            index4 = 0;
            num1 = (int) num2 * 1719152693 ^ 246247052;
            continue;
          case 12:
            num7 = num3 > this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮.Length / 2 ? 1 : 0;
            break;
          case 13:
            int num9;
            num1 = num9 = index1 >= length3 ? -691230087 : (num9 = -1459254981);
            continue;
          case 14:
            wheel1 = this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮[index2];
            num1 = -1702227780;
            continue;
          case 15:
            this.onBeforeUpdateBlocks();
            num1 = (int) num2 * -144993301 ^ 1730188158;
            continue;
          case 16:
            VehicleBase.\u202E‏‪⁮‌‭‏⁫‭‍‭⁫‫‍‪⁯⁪⁬‫‌⁯‏‪‭⁭⁯​‌⁪‬‎‎‍​⁬‭‮‬‭⁭‮.Integrate(this.\u200B​‫‏⁬⁬‌⁫⁪​⁯‪⁮​⁪‌⁪‫‌⁬⁭​‮⁮‮⁯‪‏‍‮‬‌‏⁪‍⁫⁮‪‍‪‮, Time.get_deltaTime(), this.integrationSteps, this.integrationUseRK4);
            num1 = -530675184;
            continue;
          case 17:
            wheel2 = this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮[index1];
            num1 = -1161850054;
            continue;
          case 18:
            num4 = Mathf.Max(wheelState1.brakeTorque, wheelState1.downforce * num6 * wheel2.radius);
            num1 = (int) num2 * -568513516 ^ -389677328;
            continue;
          case 19:
            this.\u206E⁮‮⁬‎⁬⁫​‬‫‫⁮‫⁪⁬‍⁫⁮⁬‎⁮‍⁮⁯⁯‬⁬​‎‮⁪⁫⁪⁪⁫‭‍‏⁮⁯‮(wheelState4, num5);
            num1 = (int) num2 * -1757265437 ^ 564413130;
            continue;
          case 20:
            ++index1;
            num1 = (int) num2 * 803395515 ^ 2090110659;
            continue;
          case 21:
            int num10 = !this.\u202C‬⁭⁮⁫‫‮‌⁪‬⁫‍‮​⁯‪‌⁪‮‎​‬⁫‏⁫‏​⁭‌‫⁬⁯‪⁫‌‏‮‌⁮‌‮ ? 843254085 : (num10 = 1391020469);
            num1 = num10 ^ (int) num2 * 265820230;
            continue;
          case 22:
            int num11;
            num1 = num11 = index3 >= length2 ? -653305626 : (num11 = -1049018259);
            continue;
          case 23:
            wheelState3.brakeTorque = wheel1.brakeTorque;
            num1 = (int) num2 * -1612353101 ^ -464567627;
            continue;
          case 24:
            wheelStateArray = this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮;
            num1 = (int) num2 * -1760864411 ^ -1155215732;
            continue;
          case 25:
            int num12;
            num1 = num12 = index4 >= wheelStateArray.Length ? -783794293 : (num12 = -1395762054);
            continue;
          case 26:
            this.\u200F⁯‪‎‏⁬⁬⁪‌⁮‬‫‬‫⁪‮‭⁫⁬‪‫‍⁬​‍‮‫‬‎⁪⁬‌⁫‪‌‫‍‏‬⁪‮(wheelState3);
            num1 = (int) num2 * -1968112979 ^ -2118373910;
            continue;
          case 27:
            int num13 = this.onBeforeUpdateBlocks != null ? -168769481 : (num13 = -2037948175);
            num1 = num13 ^ (int) num2 * 605965318;
            continue;
          case 28:
            ++index4;
            num1 = (int) num2 * 1608364174 ^ -656388581;
            continue;
          case 29:
            wheelState4 = wheelStateArray[index4];
            num1 = -567313220;
            continue;
          case 30:
            index4 = 0;
            num1 = (int) num2 * -1148971260 ^ 678975478;
            continue;
          case 31:
            int num14;
            num1 = num14 = !this.\u200D⁮‌⁫⁪⁫‏‮⁭‫⁭‮‍⁭​⁮⁫‪​‬‬‪‬⁪‏⁪‬‭⁬‪‍‌‫‮‎‬‌⁪⁪‮‮[index3].isResting ? -1134260420 : (num14 = -641790885);
            continue;
          case 32:
            this.inhibitWheelSleep = false;
            this.DoUpdateData();
            num1 = (int) num2 * 60399779 ^ 2065789077;
            continue;
          case 33:
            num1 = (int) num2 * 1913385884 ^ -651131165;
            continue;
          case 34:
            wheel2.load = wheelState1.downforce * num6;
            wheel2.grip = wheelState1.groundMaterial != null ? wheelState1.groundMaterial.grip : 1f;
            num1 = -514537935;
            continue;
          case 35:
            this.onBeforeIntegrationStep();
            num1 = (int) num2 * 1575257182 ^ -1888338800;
            continue;
          case 36:
            int num15;
            num1 = num15 = index4 >= wheelStateArray.Length ? -1568050592 : (num15 = -867149353);
            continue;
          case 37:
            this.\u200B⁮‍​‪‭​‫‪‭‭‫⁬⁭⁪⁭‫‫⁮⁮‍‌‫‎⁫⁮‍‍‎‫‭​⁯‎‮‬‍‌⁪⁫‮();
            num1 = (int) num2 * 612203225 ^ -1304736599;
            continue;
          case 38:
            this.\u206F⁫‏‭⁬‪⁭‎‍‏⁮⁯‬‍‮⁫‍⁭⁪‬⁭⁫‏⁭‏​‮‪⁮⁯‍‏⁪‏‫‭‎‭‭‏‮(wheelState4);
            num1 = (int) num2 * 2028579063 ^ 1487292723;
            continue;
          case 39:
            this.\u200F‪‭⁬⁭‎‎⁬‏‌⁯‭⁫‏‎⁮‮⁯‫‮‍⁫⁬‎⁯​‌‬‏⁯‭⁭⁮‎⁬‪‮‬⁫⁫‮();
            this.\u200B​‫‏⁬⁬‌⁫⁪​⁯‪⁮​⁪‌⁪‫‌⁬⁭​‮⁮‮⁯‪‏‍‮‬‌‏⁪‍⁫⁮‪‍‪‮ += Time.get_deltaTime();
            num1 = (int) num2 * 75441690 ^ 626971170;
            continue;
          case 40:
            wheelState3.wheelCol.canSleep = !this.inhibitWheelSleep && (flag1 ? flag2 : flag2 && wheel1.isResting);
            num1 = -750833656;
            continue;
          case 41:
            this.\u206D‍‏‮‫​⁭​‏⁫‌⁯⁫‭‌⁮‬⁪⁭⁫‪​⁬⁯‭⁭⁬‍‬‪‌‏‬‏⁬‌‮‭‭‎‮();
            num5 = this.\u206C‏‭⁮⁯‭‍‎‬⁫⁮⁮⁪‫​‏‪‎‏‫⁫⁪‫‫⁭⁮⁫⁯‪‍​‍⁮​‌⁫‏⁮⁪⁬‮.get_mass() * 9.807f / (float) this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮.Length;
            num1 = (int) num2 * 53366927 ^ -768222203;
            continue;
          case 42:
            this.\u200E‌‪⁬‍⁮‌‮‪⁯⁫‫⁬‬‬⁮⁬‬‌‍⁯‪‬⁫‬‬‪⁮​‌‮‌⁪‍‫⁭‍‮‮‏‮(wheelState2);
            num1 = (int) num2 * 1847002812 ^ 1617274070;
            continue;
          case 43:
            index2 = 0;
            length1 = this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮.Length;
            num1 = (int) num2 * -1422960590 ^ -1401426567;
            continue;
          case 44:
            ++index4;
            num1 = (int) num2 * -33103280 ^ -464445106;
            continue;
          case 45:
            num1 = (int) num2 * -27882075 ^ 731092643;
            continue;
          case 46:
            wheelState3 = this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮[index2];
            wheelState3.angularVelocity = wheel1.angularVelocity;
            wheelState3.tireForce = Vector2.op_Multiply(wheel1.F, this.scaleFactor);
            wheelState3.reactionTorque = wheel1.Tr;
            num1 = (int) num2 * 1157394200 ^ -880790410;
            continue;
          case 47:
            int num16 = !this.disableContactProcessing ? 1410312977 : (num16 = 1567377231);
            num1 = num16 ^ (int) num2 * 72930802;
            continue;
          case 48:
            int num17;
            num1 = num17 = index2 >= length1 ? -1347665366 : (num17 = -1551895508);
            continue;
          case 49:
            this.\u202C‬⁭⁮⁫‫‮‌⁪‬⁫‍‮​⁯‪‌⁪‮‎​‬⁫‏⁫‏​⁭‌‫⁬⁯‪⁫‌‏‮‌⁮‌‮ = false;
            num1 = -714806611;
            continue;
          case 50:
            ++index2;
            num1 = (int) num2 * 940815154 ^ 1788657366;
            continue;
          case 51:
            this.\u206A⁯‌⁯‮‍⁮​‮⁬‌⁬‮⁪⁮⁪⁮‏⁪‪⁮⁯⁭⁭‏⁭‏‏⁮‭⁬⁭‌‏‎⁮‬‬‌‫‮();
            num1 = -911377531;
            continue;
          case 52:
            length2 = this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮.Length;
            num1 = (int) num2 * 1618519849 ^ -1377361314;
            continue;
          case 53:
            wheelState3.tireSlip.y = (__Null) (wheelState3.localWheelVelocity.y - (double) wheelState3.angularVelocity * (double) wheel1.radius);
            wheelState3.combinedTireSlip = VehicleBase.\u202B​⁯‏⁯⁭⁬​⁬⁬⁫‌‌⁬‮⁭‪⁬⁮‪‮⁪‎‭⁯‭‌‪⁪‏‫​‫⁬⁫​‫‍‪‏‮(wheelState3.localWheelVelocity, wheelState3.tireSlip);
            wheelState3.driveTorque = wheel1.driveTorque;
            num1 = (int) num2 * 969012158 ^ 1738589635;
            continue;
          case 54:
            VPWheelCollider.scaleFactor = this.scaleFactor;
            num1 = -1052147143;
            continue;
          case 55:
            this.\u206C‏‭⁮⁯‭‍‎‬⁫⁮⁮⁪‫​‏‪‎‏‫⁫⁪‫‫⁭⁮⁫⁯‪‍​‍⁮​‌⁫‏⁮⁪⁬‮.set_maxDepenetrationVelocity(1f);
            num1 = (int) num2 * 1859427084 ^ 764047274;
            continue;
          case 56:
            num1 = (int) num2 * -967077434 ^ 1020640084;
            continue;
          case 57:
            this.DoUpdateBlocks();
            num1 = -474948299;
            continue;
          case 58:
            num3 = 0;
            index3 = 0;
            num1 = (int) num2 * -1864198331 ^ -1811526132;
            continue;
          case 59:
            wheel2.V = wheelState1.localWheelVelocity;
            wheel2.Fext = Vector2.op_Multiply(wheelState1.externalTireForce, num6);
            num1 = (int) num2 * -2122956226 ^ 1767579410;
            continue;
          case 60:
            int num18;
            num1 = num18 = !this.paused ? -714806611 : (num18 = -1490588489);
            continue;
          case 61:
            this.\u206B‏‌‏⁪⁭‪​⁯⁫⁪⁯⁭‮⁯⁫‎‮‮‭‬‮‮‎⁯⁭‬‭‪‮‮⁭‪‌⁭‎‌‎‬‬‮();
            num1 = (int) num2 * 1060536590 ^ 55416913;
            continue;
          case 62:
            goto label_29;
          case 63:
            goto label_1;
          case 64:
            this.onPreDynamicsStep();
            num1 = (int) num2 * -152588886 ^ 1423572404;
            continue;
          case 65:
            ++num3;
            num1 = (int) num2 * -1152711258 ^ -363811350;
            continue;
          case 66:
            flag2 = (double) ((Vector2) ref wheelState3.localWheelVelocity).get_magnitude() < (double) this.wheelSleepVelocity;
            num1 = (int) num2 * -404058171 ^ -63846512;
            continue;
          case 67:
            this.\u206C‏‭⁮⁯‭‍‎‬⁫⁮⁮⁪‫​‏‪‎‏‫⁫⁪‫‫⁭⁮⁫⁯‪‍​‍⁮​‌⁫‏⁮⁪⁬‮.set_maxDepenetrationVelocity(Mathf.Lerp(8f, 1f, magnitude));
            num1 = -1750216610;
            continue;
          case 68:
            if (this.vehicleSleepCriteria == VehicleBase.VehicleSleepCriteria.Strict)
            {
              num7 = num3 >= this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮.Length / 2 ? 1 : 0;
              break;
            }
            num1 = (int) num2 * -1247811551 ^ 1431849234;
            continue;
          case 69:
            magnitude = ((Vector3) ref velocity).get_magnitude();
            int num19 = (double) magnitude > 1.0 ? -812806809 : (num19 = -1290936925);
            num1 = num19 ^ (int) num2 * 1285970290;
            continue;
          case 70:
            ++index3;
            num1 = -76958460;
            continue;
          case 71:
            int num20 = this.onBeforeIntegrationStep == null ? 496824988 : (num20 = 1805414047);
            num1 = num20 ^ (int) num2 * -1459046774;
            continue;
          default:
            goto label_77;
        }
        flag1 = num7 != 0;
        num1 = -945098855;
      }
label_3:
      return;
label_29:
      return;
label_77:;
    }

    private void Update()
    {
      if (!this.paused)
        goto label_11;
label_1:
      int num1 = 1621926120;
label_2:
      bool flag;
      int index;
      int wheelCount;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ 321657500)) % 22U)
        {
          case 0:
            num1 = (int) num2 * 735845257 ^ 165591157;
            continue;
          case 1:
            this.\u202D‏‍‎‮‬‎⁯‫​‭‏⁯‌‌‎⁯‮‪⁬‭‬⁬⁬⁭⁫‬‫⁯‪⁮⁭⁫‪⁭⁬⁪‎​⁯‮();
            num1 = (int) num2 * 1347514846 ^ -1274561040;
            continue;
          case 2:
            this.onPreVisualUpdate();
            num1 = (int) num2 * 1585619484 ^ -794729668;
            continue;
          case 3:
            this.OnUpdate();
            num1 = 187407893;
            continue;
          case 4:
            int num3 = flag ? -1467065925 : (num3 = -2010952653);
            num1 = num3 ^ (int) num2 * 1963115555;
            continue;
          case 5:
            int num4 = this.\u206D⁭⁬‏‫⁭‏⁫⁬​⁪⁮‍‎⁭‫⁫‎‬‭‬⁫‪⁪​⁮‮‭‪⁭⁭⁭‪‫‍‏⁯‭‎⁯‮ ? -1714468038 : (num4 = -179357901);
            num1 = num4 ^ (int) num2 * 1613292130;
            continue;
          case 6:
            flag = this.\u206C‏‭⁮⁯‭‍‎‬⁫⁮⁮⁪‫​‏‪‎‏‫⁫⁪‫‫⁭⁮⁫⁯‪‍​‍⁮​‌⁫‏⁮⁪⁬‮.get_interpolation() > 0;
            num1 = 1474820226;
            continue;
          case 7:
            int num5;
            num1 = num5 = index >= wheelCount ? 2018479527 : (num5 = 751936057);
            continue;
          case 8:
            this.\u206B‮‌‏‏‌‭⁭‬⁪‬‍⁮⁮⁬‫‫‍‏​⁪⁮‫‬‌‏⁮‫⁫​‎⁬⁬‍‏‬‍⁫⁪‌‮(Vector3.get_zero(), Vector3.get_zero(), this.\u200E‏‮⁯⁪⁮‍⁮‫‭‭‭⁫‬⁭⁪⁫⁫‬‮‌⁯‎‬‫​⁫⁪‌⁮‌‭⁯‬⁭‎‮‍‫⁪‮);
            num1 = (int) num2 * -1632913431 ^ 1182996969;
            continue;
          case 9:
            VehicleBase.WheelState wheelState = this.\u202B⁬⁯​‬‏⁬‎‫⁯⁫‮‍‬‭‍‏⁯‏‎‪‬⁬⁬‭‎​‪‌‫‌⁪‍‫⁫‮‍⁭‮⁪‮[index];
            wheelState.wheelCol.steerAngle = wheelState.steerAngle;
            wheelState.wheelCol.angularVelocity = this.invertVisualWheelSpinDirection ? -wheelState.angularVelocity : wheelState.angularVelocity;
            wheelState.wheelCol.UpdateVisualWheel(this.paused ? Time.get_fixedDeltaTime() : Time.get_deltaTime());
            ++index;
            num1 = 467098373;
            continue;
          case 10:
            goto label_19;
          case 11:
            goto label_3;
          case 12:
            goto label_1;
          case 13:
            this.invertVisualWheelSpinDirection = false;
            int num6 = flag ? 340165255 : (num6 = 1433249472);
            num1 = num6 ^ (int) num2 * -646596233;
            continue;
          case 14:
            int num7 = this.\u202C‬⁭⁮⁫‫‮‌⁪‬⁫‍‮​⁯‪‌⁪‮‎​‬⁫‏⁫‏​⁭‌‫⁬⁯‪⁫‌‏‮‌⁮‌‮ ? -1950550483 : (num7 = -1498927863);
            num1 = num7 ^ (int) num2 * -427779137;
            continue;
          case 15:
            int num8;
            num1 = num8 = this.disableContactProcessing ? 648249535 : (num8 = 1985852538);
            continue;
          case 16:
            goto label_11;
          case 17:
            index = 0;
            num1 = 1055669945;
            continue;
          case 18:
            this.\u200B‎‭‪‍⁭‭⁬⁪‍‏‪⁯⁮‮‪⁭‎⁮⁪⁬⁭⁯⁯‪⁯⁮‏⁬‭⁪‮‏⁮⁫‬‍‌⁯⁪‮();
            num1 = (int) num2 * -1281343172 ^ 34257925;
            continue;
          case 19:
            wheelCount = this.wheelCount;
            num1 = (int) num2 * 1184421237 ^ 852290693;
            continue;
          case 20:
            this.\u206D⁭⁬‏‫⁭‏⁫⁬​⁪⁮‍‎⁭‫⁫‎‬‭‬⁫‪⁪​⁮‮‭‪⁭⁭⁭‪‫‍‏⁯‭‎⁯‮ = false;
            num1 = 1020655064;
            continue;
          case 21:
            this.\u200C‬‮‫‬‌‎​‪‬⁭‮‮⁬‏‮‏‭‌‪⁫‌‮⁯‪‫‭‫‮‮⁯‌‭‏‎‫​‎⁪‮();
            num1 = (int) num2 * 1718466926 ^ 1879765791;
            continue;
          default:
            goto label_24;
        }
      }
label_19:
      return;
label_3:
      return;
label_24:
      return;
label_11:
      num1 = this.onPreVisualUpdate != null ? 951802182 : (num1 = 781073636);
      goto label_2;
    }

    private void \u206C‍‏⁫⁭‭⁪​⁯‏‫‬‎⁪‬⁪⁯​‫⁯⁪‎‏⁬⁭⁫‍⁮‍‮⁭⁪⁪‏‪⁪‍⁪‏⁫‮()
    {
      VehicleBehaviour[] componentsInChildren = (VehicleBehaviour[]) ((Component) this).GetComponentsInChildren<VehicleBehaviour>(true);
      int index = 0;
label_1:
      int num1 = 60817276;
      VehicleBehaviour vehicleBehaviour;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ 1082315852)) % 10U)
        {
          case 0:
            goto label_3;
          case 1:
            this.\u200C⁯⁪‮‍⁮‏⁭‬⁮‪‏⁫⁮⁪‪‎‪‎‫⁯‎‬​⁯‮​‌‌‎‍⁭‬‎‪‎‭‮⁬‮(vehicleBehaviour);
            num1 = 948607668;
            continue;
          case 2:
            num1 = (int) num2 * -751447805 ^ 913750367;
            continue;
          case 3:
            goto label_1;
          case 4:
            ++index;
            num1 = 754911439;
            continue;
          case 5:
            int num3 = ((Component) vehicleBehaviour).get_gameObject().get_activeInHierarchy() ? -732386757 : (num3 = -340584961);
            num1 = num3 ^ (int) num2 * 983492888;
            continue;
          case 6:
            vehicleBehaviour = componentsInChildren[index];
            int num4;
            num1 = num4 = ((Behaviour) vehicleBehaviour).get_enabled() ? 1009381025 : (num4 = 1933979335);
            continue;
          case 7:
            this.\u206E⁭⁭​‎‍‏⁪‌‎⁮‫⁭​‍‎‭‍‫‍⁬‫‫⁬⁮‬‌‏‍⁭⁪‫⁮‎‌‎⁫⁭‫⁫‮(vehicleBehaviour);
            num1 = (int) num2 * -979037194 ^ -1303696210;
            continue;
          case 8:
            num1 = (int) num2 * 1284103878 ^ -1084993404;
            continue;
          case 9:
            int num5;
            num1 = num5 = index >= componentsInChildren.Length ? 1071813118 : (num5 = 451630456);
            continue;
          default:
            goto label_12;
        }
      }
label_3:
      return;
label_12:;
    }

    private void \u206C⁮‎‌⁫‌⁪‍‏‍‌⁪‮‫‭⁭‮⁮‭‌‌‌‭⁫⁯‬‮‪⁪⁫‫⁪‫‏⁬‬⁬⁯⁬⁯‮()
    {
label_5:
      int num1 = this.\u206B‫⁯⁭⁫‬⁪‮‪⁯⁭⁪⁫‪‮‍‫‭‮‏‌⁮‏⁭‬‪‏‬‫‭‪‌‍‍‮⁫⁬‪‫⁬‮.Count <= 0 ? -53673880 : (num1 = -334235217);
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -617714938)) % 4U)
        {
          case 0:
            num1 = -334235217;
            continue;
          case 1:
            this.\u200C⁯⁪‮‍⁮‏⁭‬⁮‪‏⁫⁮⁪‪‎‪‎‫⁯‎‬​⁯‮​‌‌‎‍⁭‬‎‪‎‭‮⁬‮(this.\u206B‫⁯⁭⁫‬⁪‮‪⁯⁭⁪⁫‪‮‍‫‭‮‏‌⁮‏⁭‬‪‏‬‫‭‪‌‍‍‮⁫⁬‪‫⁬‮[0]);
            num1 = -2095467575;
            continue;
          case 2:
            goto label_3;
          case 3:
            goto label_5;
          default:
            goto label_6;
        }
      }
label_3:
      return;
label_6:;
    }

    private void \u200F‪‭⁬⁭‎‎⁬‏‌⁯‭⁫‏‎⁮‮⁯‫‮‍⁫⁬‎⁯​‌‬‏⁯‭⁭⁮‎⁬‪‮‬⁫⁫‮()
    {
      int index = 0;
label_1:
      int num1 = 729899203;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ 482999699)) % 6U)
        {
          case 0:
            goto label_3;
          case 1:
            ++index;
            num1 = (int) num2 * -1309036013 ^ 1988712237;
            continue;
          case 2:
            this.\u206B‫⁯⁭⁫‬⁪‮‪⁯⁭⁪⁫‪‮‍‫‭‮‏‌⁮‏⁭‬‪‏‬‫‭‪‌‍‍‮⁫⁬‪‫⁬‮[index].FixedUpdateVehicle();
            num1 = 112882756;
            continue;
          case 3:
            int num3;
            num1 = num3 = index >= this.\u206B‫⁯⁭⁫‬⁪‮‪⁯⁭⁪⁫‪‮‍‫‭‮‏‌⁮‏⁭‬‪‏‬‫‭‪‌‍‍‮⁫⁬‪‫⁬‮.Count ? 1293124545 : (num3 = 1010327641);
            continue;
          case 4:
            num1 = (int) num2 * -1681459188 ^ 2024550424;
            continue;
          case 5:
            goto label_1;
          default:
            goto label_8;
        }
      }
label_3:
      return;
label_8:;
    }

    private void \u202D‏‍‎‮‬‎⁯‫​‭‏⁯‌‌‎⁯‮‪⁬‭‬⁬⁬⁭⁫‬‫⁯‪⁮⁭⁫‪⁭⁬⁪‎​⁯‮()
    {
      int index = 0;
label_6:
      int num1 = index >= this.\u206B‫⁯⁭⁫‬⁪‮‪⁯⁭⁪⁫‪‮‍‫‭‮‏‌⁮‏⁭‬‪‏‬‫‭‪‌‍‍‮⁫⁬‪‫⁬‮.Count ? -1243081670 : (num1 = -1630654602);
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -1025900270)) % 5U)
        {
          case 0:
            goto label_3;
          case 1:
            goto label_6;
          case 2:
            ++index;
            num1 = (int) num2 * -135187780 ^ -1674724704;
            continue;
          case 3:
            this.\u206B‫⁯⁭⁫‬⁪‮‪⁯⁭⁪⁫‪‮‍‫‭‮‏‌⁮‏⁭‬‪‏‬‫‭‪‌‍‍‮⁫⁬‪‫⁬‮[index].UpdateVehicle();
            num1 = -819123676;
            continue;
          case 4:
            num1 = -1630654602;
            continue;
          default:
            goto label_7;
        }
      }
label_3:
      return;
label_7:;
    }

    private void \u206D‍‏‮‫​⁭​‏⁫‌⁯⁫‭‌⁮‬⁪⁭⁫‪​⁬⁯‭⁭⁬‍‬‪‌‏‬‏⁬‌‮‭‭‎‮()
    {
      int index = 0;
label_1:
      int num1 = -1612934565;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -758047609)) % 6U)
        {
          case 0:
            goto label_1;
          case 1:
            ++index;
            num1 = (int) num2 * 1997956002 ^ 827587817;
            continue;
          case 2:
            num1 = (int) num2 * -1101336919 ^ 584595123;
            continue;
          case 3:
            goto label_3;
          case 4:
            int num3;
            num1 = num3 = index >= this.\u206B‫⁯⁭⁫‬⁪‮‪⁯⁭⁪⁫‪‮‍‫‭‮‏‌⁮‏⁭‬‪‏‬‫‭‪‌‍‍‮⁫⁬‪‫⁬‮.Count ? -798867834 : (num3 = -1558217442);
            continue;
          case 5:
            this.\u206B‫⁯⁭⁫‬⁪‮‪⁯⁭⁪⁫‪‮‍‫‭‮‏‌⁮‏⁭‬‪‏‬‫‭‪‌‍‍‮⁫⁬‪‫⁬‮[index].UpdateVehicleSuspension();
            num1 = -1764955708;
            continue;
          default:
            goto label_8;
        }
      }
label_3:
      return;
label_8:;
    }

    private void \u206E⁭⁭​‎‍‏⁪‌‎⁮‫⁭​‍‎‭‍‫‍⁬‫‫⁬⁮‬‌‏‍⁭⁪‫⁮‎‌‎⁫⁭‫⁫‮(VehicleBehaviour _param1)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      VehicleBase.\u200C⁫‌‎⁯⁬⁪‪‍‌‍‭⁪⁮‭‌⁮‪‌‍‪‏‌​‎‬⁯‌‌⁬‪​⁮‏​⁪‮⁮‍⁫‮ obj = new VehicleBase.\u200C⁫‌‎⁯⁬⁪‪‍‌‍‭⁪⁮‭‌⁮‪‌‍‪‏‌​‎‬⁯‌‌⁬‪​⁮‏​⁪‮⁮‍⁫‮();
      // ISSUE: reference to a compiler-generated field
      obj.\u200B‮⁫⁫⁪⁫‬‍‪⁫‍⁮⁪⁪⁭‬⁬⁮‫‪⁬‮​⁭‍⁫‬‮⁫‮‮‮‌⁪⁮‎‌‫‮⁪‮ = _param1;
      // ISSUE: reference to a compiler-generated method
      if (Array.Exists<System.Type>(VehicleBase.\u200C⁮⁭‌⁪‪⁮‮‌⁯‬‫⁮‭‪​‌‮‍⁫‭‌‎‏⁭‫‬‎‪‫‌⁮​⁬⁫‫⁮⁭‌‪‮, new Predicate<System.Type>(obj.\u206A‫⁫⁯⁬⁭‎⁬‮⁫‭‍⁭‍‮⁪‎‍⁭⁯‏‪‫⁪⁬‌​⁭⁬⁯‬‎⁯⁪‏⁯⁭⁪‪‮‮)))
        goto label_17;
label_1:
      int num1 = -1859602033;
label_2:
      int index;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -1533025762)) % 16U)
        {
          case 0:
            goto label_14;
          case 1:
            // ISSUE: reference to a compiler-generated field
            this.DebugLogWarning(\u003CModule\u003E.\u206A‮‭‮‫⁬‪‏‬⁮‪‮‬‬⁬‏⁮‮⁪⁪⁯⁯‭‫‮⁫⁭‏‫‫⁭‍‮‍⁯​⁯‍​‏‮<string>(1530554557U) + ((object) obj.\u200B‮⁫⁫⁪⁫‬‍‪⁫‍⁮⁪⁪⁭‬⁬⁮‫‪⁬‮​⁭‍⁫‬‮⁫‮‮‮‌⁪⁮‎‌‫‮⁪‮).GetType().ToString());
            num1 = (int) num2 * -746386110 ^ 1084346601;
            continue;
          case 2:
            index = 0;
            num1 = (int) num2 * 1460732897 ^ -2085041544;
            continue;
          case 3:
            // ISSUE: reference to a compiler-generated field
            int num3 = Object.op_Equality((Object) obj.\u200B‮⁫⁫⁪⁫‬‍‪⁫‍⁮⁪⁪⁭‬⁬⁮‫‪⁬‮​⁭‍⁫‬‮⁫‮‮‮‌⁪⁮‎‌‫‮⁪‮.vehicle, (Object) null) ? 86129310 : (num3 = 1033790620);
            num1 = num3 ^ (int) num2 * 1775811800;
            continue;
          case 4:
            int num4;
            num1 = num4 = index < this.\u206B‫⁯⁭⁫‬⁪‮‪⁯⁭⁪⁫‪‮‍‫‭‮‏‌⁮‏⁭‬‪‏‬‫‭‪‌‍‍‮⁫⁬‪‫⁬‮.Count ? -1447078879 : (num4 = -383311120);
            continue;
          case 5:
            // ISSUE: reference to a compiler-generated field
            ((Behaviour) obj.\u200B‮⁫⁫⁪⁫‬‍‪⁫‍⁮⁪⁪⁭‬⁬⁮‫‪⁬‮​⁭‍⁫‬‮⁫‮‮‮‌⁪⁮‎‌‫‮⁪‮).set_enabled(false);
            num1 = (int) num2 * 1220453554 ^ -1320947352;
            continue;
          case 6:
            goto label_1;
          case 7:
            // ISSUE: reference to a compiler-generated field
            int num5 = ((Component) obj.\u200B‮⁫⁫⁪⁫‬‍‪⁫‍⁮⁪⁪⁭‬⁬⁮‫‪⁬‮​⁭‍⁫‬‮⁫‮‮‮‌⁪⁮‎‌‫‮⁪‮).get_gameObject().get_activeInHierarchy() ? -581753515 : (num5 = -1234714873);
            num1 = num5 ^ (int) num2 * -1853769473;
            continue;
          case 8:
            goto label_6;
          case 9:
            // ISSUE: reference to a compiler-generated field
            obj.\u200B‮⁫⁫⁪⁫‬‍‪⁫‍⁮⁪⁪⁭‬⁬⁮‫‪⁬‮​⁭‍⁫‬‮⁫‮‮‮‌⁪⁮‎‌‫‮⁪‮.OnEnterPause();
            num1 = (int) num2 * -441809061 ^ -559059635;
            continue;
          case 10:
            // ISSUE: reference to a compiler-generated field
            obj.\u200B‮⁫⁫⁪⁫‬‍‪⁫‍⁮⁪⁪⁭‬⁬⁮‫‪⁬‮​⁭‍⁫‬‮⁫‮‮‮‌⁪⁮‎‌‫‮⁪‮.OnEnableVehicle();
            int num6;
            // ISSUE: reference to a compiler-generated field
            num1 = num6 = ((Behaviour) obj.\u200B‮⁫⁫⁪⁫‬‍‪⁫‍⁮⁪⁪⁭‬⁬⁮‫‪⁬‮​⁭‍⁫‬‮⁫‮‮‮‌⁪⁮‎‌‫‮⁪‮).get_enabled() ? -621563863 : (num6 = -338439218);
            continue;
          case 11:
            goto label_17;
          case 12:
            goto label_3;
          case 13:
            ++index;
            num1 = -1978955462;
            continue;
          case 14:
            // ISSUE: reference to a compiler-generated field
            this.\u206B‫⁯⁭⁫‬⁪‮‪⁯⁭⁪⁫‪‮‍‫‭‮‏‌⁮‏⁭‬‪‏‬‫‭‪‌‍‍‮⁫⁬‪‫⁬‮.Insert(index, obj.\u200B‮⁫⁫⁪⁫‬‍‪⁫‍⁮⁪⁪⁭‬⁬⁮‫‪⁬‮​⁭‍⁫‬‮⁫‮‮‮‌⁪⁮‎‌‫‮⁪‮);
            int num7;
            num1 = num7 = this.paused ? -345368601 : (num7 = -338439218);
            continue;
          case 15:
            // ISSUE: reference to a compiler-generated field
            int num8 = obj.\u200B‮⁫⁫⁪⁫‬‍‪⁫‍⁮⁪⁪⁭‬⁬⁮‫‪⁬‮​⁭‍⁫‬‮⁫‮‮‮‌⁪⁮‎‌‫‮⁪‮.GetUpdateOrder() < this.\u206B‫⁯⁭⁫‬⁪‮‪⁯⁭⁪⁫‪‮‍‫‭‮‏‌⁮‏⁭‬‪‏‬‫‭‪‌‍‍‮⁫⁬‪‫⁬‮[index].GetUpdateOrder() ? 1575031169 : (num8 = 1033852674);
            num1 = num8 ^ (int) num2 * -24081841;
            continue;
          default:
            goto label_18;
        }
      }
label_14:
      return;
label_6:
      return;
label_3:
      return;
label_18:
      return;
label_17:
      // ISSUE: reference to a compiler-generated field
      num1 = !this.\u206B‫⁯⁭⁫‬⁪‮‪⁯⁭⁪⁫‪‮‍‫‭‮‏‌⁮‏⁭‬‪‏‬‫‭‪‌‍‍‮⁫⁬‪‫⁬‮.Contains(obj.\u200B‮⁫⁫⁪⁫‬‍‪⁫‍⁮⁪⁪⁭‬⁬⁮‫‪⁬‮​⁭‍⁫‬‮⁫‮‮‮‌⁪⁮‎‌‫‮⁪‮) ? -504312611 : (num1 = -338439218);
      goto label_2;
    }

    private void \u200C⁯⁪‮‍⁮‏⁭‬⁮‪‏⁫⁮⁪‪‎‪‎‫⁯‎‬​⁯‮​‌‌‎‍⁭‬‎‪‎‭‮⁬‮(VehicleBehaviour _param1)
    {
      if (!this.\u206B‫⁯⁭⁫‬⁪‮‪⁯⁭⁪⁫‪‮‍‫‭‮‏‌⁮‏⁭‬‪‏‬‫‭‪‌‍‍‮⁫⁬‪‫⁬‮.Contains(_param1))
        return;
label_1:
      int num1 = 1169671565;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ 1091088480)) % 6U)
        {
          case 0:
            this.\u206B‫⁯⁭⁫‬⁪‮‪⁯⁭⁪⁫‪‮‍‫‭‮‏‌⁮‏⁭‬‪‏‬‫‭‪‌‍‍‮⁫⁬‪‫⁬‮.Remove(_param1);
            num1 = (int) num2 * 1531584672 ^ -1380028551;
            continue;
          case 1:
            goto label_8;
          case 2:
            goto label_1;
          case 3:
            int num3 = !this.paused ? -1680245949 : (num3 = -2009897904);
            num1 = num3 ^ (int) num2 * 1545536032;
            continue;
          case 4:
            _param1.OnLeavePause();
            num1 = (int) num2 * 999827320 ^ -563185821;
            continue;
          case 5:
            _param1.OnDisableVehicle();
            num1 = 2021205944;
            continue;
          default:
            goto label_9;
        }
      }
label_8:
      return;
label_9:;
    }

    public void RegisterVehicleBehaviour(VehicleBehaviour vb)
    {
      if (!this.initialized)
        return;
label_1:
      int num1 = -1544269200;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -2043994920)) % 3U)
        {
          case 0:
            goto label_1;
          case 1:
            goto label_5;
          case 2:
            this.\u206E⁭⁭​‎‍‏⁪‌‎⁮‫⁭​‍‎‭‍‫‍⁬‫‫⁬⁮‬‌‏‍⁭⁪‫⁮‎‌‎⁫⁭‫⁫‮(vb);
            num1 = (int) num2 * 404879222 ^ 1682329938;
            continue;
          default:
            goto label_6;
        }
      }
label_5:
      return;
label_6:;
    }

    public void UnregisterVehicleBehaviour(VehicleBehaviour vb)
    {
      if (!this.initialized)
        return;
label_1:
      int num1 = -1788774630;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -982627356)) % 3U)
        {
          case 0:
            goto label_1;
          case 1:
            this.\u200C⁯⁪‮‍⁮‏⁭‬⁮‪‏⁫⁮⁪‪‎‪‎‫⁯‎‬​⁯‮​‌‌‎‍⁭‬‎‪‎‭‮⁬‮(vb);
            num1 = (int) num2 * -552146695 ^ -1856576965;
            continue;
          case 2:
            goto label_5;
          default:
            goto label_6;
        }
      }
label_5:
      return;
label_6:;
    }

    private void \u200B‭‌‭⁭⁪⁫‏‌‭⁬⁯⁯⁫⁫​⁮‏‍‌‍‍‫‌⁬⁯‏‭⁯​⁬‌‍⁬⁬‏‮‮‮‌‮()
    {
      if (!this.initialized)
        return;
label_1:
      int num1 = -1178094234;
      int index;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -1847343663)) % 7U)
        {
          case 0:
            goto label_9;
          case 1:
            index = 0;
            num1 = (int) num2 * -416601727 ^ -1547467825;
            continue;
          case 2:
            this.\u206B‫⁯⁭⁫‬⁪‮‪⁯⁭⁪⁫‪‮‍‫‭‮‏‌⁮‏⁭‬‪‏‬‫‭‪‌‍‍‮⁫⁬‪‫⁬‮[index].OnReposition();
            num1 = -1175384606;
            continue;
          case 3:
            ++index;
            num1 = (int) num2 * 434927902 ^ -70196701;
            continue;
          case 4:
            num1 = (int) num2 * -2008128997 ^ 99219338;
            continue;
          case 5:
            int num3;
            num1 = num3 = index >= this.\u206B‫⁯⁭⁫‬⁪‮‪⁯⁭⁪⁫‪‮‍‫‭‮‏‌⁮‏⁭‬‪‏‬‫‭‪‌‍‍‮⁫⁬‪‫⁬‮.Count ? -347199636 : (num3 = -300190521);
            continue;
          case 6:
            goto label_1;
          default:
            goto label_10;
        }
      }
label_9:
      return;
label_10:;
    }

    private void \u202C‍‎⁭‪‫⁮⁭⁯‭⁬⁮⁬‌⁫⁮‪‪‍⁬‮⁯‪⁯‏​‏‍⁪⁪‫‏⁮‪‮⁯⁪‮‪⁭‮()
    {
      if (!this.initialized)
        return;
label_1:
      int num1 = 941812641;
      int index;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ 1051382646)) % 6U)
        {
          case 0:
            goto label_1;
          case 1:
            num1 = (int) num2 * -1166440040 ^ -1770424546;
            continue;
          case 2:
            this.\u206B‫⁯⁭⁫‬⁪‮‪⁯⁭⁪⁫‪‮‍‫‭‮‏‌⁮‏⁭‬‪‏‬‫‭‪‌‍‍‮⁫⁬‪‫⁬‮[index].OnEnterPause();
            ++index;
            num1 = 1997874134;
            continue;
          case 3:
            goto label_8;
          case 4:
            int num3;
            num1 = num3 = index < this.\u206B‫⁯⁭⁫‬⁪‮‪⁯⁭⁪⁫‪‮‍‫‭‮‏‌⁮‏⁭‬‪‏‬‫‭‪‌‍‍‮⁫⁬‪‫⁬‮.Count ? 1710929460 : (num3 = 2109082185);
            continue;
          case 5:
            index = 0;
            num1 = (int) num2 * 239085034 ^ -1607468557;
            continue;
          default:
            goto label_9;
        }
      }
label_8:
      return;
label_9:;
    }

    private void \u202C⁫​⁫⁪‏‬‏⁬⁭⁫‭⁬⁮⁪⁫‮‫⁪‮‫‭‫⁯‭⁯‭⁫‏‭⁫​⁮⁪‮⁯‪‬⁫⁬‮()
    {
      if (!this.initialized)
        return;
label_1:
      int num1 = -870988248;
      int index;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -1744275008)) % 5U)
        {
          case 0:
            goto label_1;
          case 1:
            index = 0;
            num1 = (int) num2 * -1765375793 ^ -235996065;
            continue;
          case 2:
            this.\u206B‫⁯⁭⁫‬⁪‮‪⁯⁭⁪⁫‪‮‍‫‭‮‏‌⁮‏⁭‬‪‏‬‫‭‪‌‍‍‮⁫⁬‪‫⁬‮[index].OnLeavePause();
            ++index;
            num1 = -1331900217;
            continue;
          case 3:
            goto label_7;
          case 4:
            int num3;
            num1 = num3 = index < this.\u206B‫⁯⁭⁫‬⁪‮‪⁯⁭⁪⁫‪‮‍‫‭‮‏‌⁮‏⁭‬‪‏‬‫‭‪‌‍‍‮⁫⁬‪‫⁬‮.Count ? -1029615752 : (num3 = -2132761728);
            continue;
          default:
            goto label_8;
        }
      }
label_7:
      return;
label_8:;
    }

    public void DebugLogWarning(string message) => Debug.LogWarning((object) (((object) this).ToString() + \u003CModule\u003E.\u206A‮‭‮‫⁬‪‏‬⁮‪‮‬‬⁬‏⁮‮⁪⁪⁯⁯‭‫‮⁫⁭‏‫‫⁭‍‮‍⁯​⁯‍​‏‮<string>(1269727989U) + message + \u003CModule\u003E.\u200C‭⁫‪‍⁯‬‮​⁮‌⁫‫‏⁭⁬‪‬‌‪‍⁪⁪‍‮⁭‍‌‭‎​‭⁭​‏‬‮‭⁯⁯‮<string>(1767580447U)), (Object) this);

    public void DebugLogError(string message) => Debug.LogError((object) (((object) this).ToString() + \u003CModule\u003E.\u206A‮‭‮‫⁬‪‏‬⁮‪‮‬‬⁬‏⁮‮⁪⁪⁯⁯‭‫‮⁫⁭‏‫‫⁭‍‮‍⁯​⁯‍​‏‮<string>(1269727989U) + message + \u003CModule\u003E.\u200C‭⁫‪‍⁯‬‮​⁮‌⁫‫‏⁭⁬‪‬‌‪‍⁪⁪‍‮⁭‍‌‭‎​‭⁭​‏‬‮‭⁯⁯‮<string>(1767580447U)), (Object) this);

    public Vector3 localImpactPosition => this.\u200D​‎‪‪⁯‪​⁯⁬​⁬‪​‍⁭⁭‭‏​‏⁬‪‮⁪‌⁭⁭‫‬​⁭⁪⁮⁮‏‌⁮‫‎‮;

    public Vector3 localImpactVelocity => this.\u206D‬⁪⁬⁯‭⁯⁯‬‏⁪‬​‫‫⁮‍⁮⁫‌‬‭‫‎‪⁪​⁪‮⁮‍⁭‍​‫‫‪‮‬⁮‮;

    public bool isHardImpact => this.\u202C‮‪​‬‮‍‮⁮‪‪⁬‪‬⁬‫⁬‮⁬⁬‏​‏⁭⁭⁯​⁯‏⁮‪⁭‭‮⁯‫‬⁬‍‏‮ >= 0;

    public Vector3 localDragPosition => this.\u200F⁭⁫‍⁪‍⁭‬⁯⁭⁭‫‎​⁭⁬‌⁯⁫⁬‎‎⁮‍⁮⁯‏‏⁫‫‫‮‮⁯⁮‍‏⁪⁪⁯‮;

    public Vector3 localDragVelocity => this.\u206E⁬‏‪‪‮‭‌⁯⁭⁯⁪⁫⁫​‫‍⁯‫‌‫‭⁮‫‮‫⁭‏‮‮⁪⁮​⁬‏‪‬‮‍‎‮;

    public bool isHardDrag => this.\u200E‏‮⁯⁪⁮‍⁮‫‭‭‭⁫‬⁭⁪⁫⁫‬‮‌⁯‎‬‫​⁫⁪‌⁮‌‭⁯‬⁭‎‮‍‫⁪‮ >= 0;

    public Collider lastContactedCollider { get; private set; }

    private void \u200C‪‍⁮⁬⁪‪​​⁭⁪‍​⁫‫⁭⁬⁭‍​⁭⁪‌‏‍‬⁭⁪‮‪⁫⁫‫‭‮⁬‎⁯‍‮()
    {
      this.\u206C⁫⁭‭‭⁭⁫⁭‬⁫‏⁮‎‪⁭⁫⁭⁯​‫⁭‍⁫⁪​‎‏‭​‮⁪⁫⁮⁯‮‍‌⁯⁮‍‮ = 0;
label_1:
      int num1 = 1645900847;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ 815499385)) % 7U)
        {
          case 0:
            this.\u206E‬‌‬‫​⁫​⁪‌‬⁬​‮‍‎⁯⁭⁭‫‫‮‭‭‫‬‎⁮‫‌​⁭‌⁯⁯‫⁪‪⁪‍‮ = 0.0f;
            num1 = (int) num2 * 1127491697 ^ -763185870;
            continue;
          case 1:
            this.\u206D‬⁪⁬⁯‭⁯⁯‬‏⁪‬​‫‫⁮‍⁮⁫‌‬‭‫‎‪⁪​⁪‮⁮‍⁭‍​‫‫‪‮‬⁮‮ = Vector3.get_zero();
            num1 = (int) num2 * 2082779712 ^ -433405597;
            continue;
          case 2:
            this.\u200F⁭⁫‍⁪‍⁭‬⁯⁭⁭‫‎​⁭⁬‌⁯⁫⁬‎‎⁮‍⁮⁯‏‏⁫‫‫‮‮⁯⁮‍‏⁪⁪⁯‮ = Vector3.get_zero();
            this.\u206E⁬‏‪‪‮‭‌⁯⁭⁯⁪⁫⁫​‫‍⁯‫‌‫‭⁮‫‮‫⁭‏‮‮⁪⁮​⁬‏‪‬‮‍‎‮ = Vector3.get_zero();
            num1 = (int) num2 * 611109862 ^ -188359438;
            continue;
          case 3:
            this.\u202C‮‪​‬‮‍‮⁮‪‪⁬‪‬⁬‫⁬‮⁬⁬‏​‏⁭⁭⁯​⁯‏⁮‪⁭‭‮⁯‫‬⁬‍‏‮ = 0;
            num1 = (int) num2 * 40786309 ^ 2012996873;
            continue;
          case 4:
            goto label_1;
          case 6:
            this.\u200D​‎‪‪⁯‪​⁯⁬​⁬‪​‍⁭⁭‭‏​‏⁬‪‮⁪‌⁭⁭‫‬​⁭⁪⁮⁮‏‌⁮‫‎‮ = Vector3.get_zero();
            num1 = (int) num2 * -1233434399 ^ 775970516;
            continue;
          default:
            goto label_8;
        }
      }
label_8:
      this.\u200E‏‮⁯⁪⁮‍⁮‫‭‭‭⁫‬⁭⁪⁫⁫‬‮‌⁯‎‬‫​⁫⁪‌⁮‌‭⁯‬⁭‎‮‍‫⁪‮ = 0;
      this.\u200F‎‬‍‌‫‎‬⁮‮‬‭‫‍⁮⁬‭‮‎‮‪‏‌‏‌‮‏​‌⁫‬‫‏‬​⁯⁯‌‫‍‮.physicMaterial = (PhysicMaterial) null;
      this.\u202E‬⁮‭‪​⁬‭‭⁪⁯‎⁫‬‌⁭‏⁮‪⁮‏‎⁬⁭‍​⁫‪​⁭​‎‮‪‭⁭⁬‍‮⁭‮ = (GroundMaterial) null;
    }

    private void \u200D‌‪‭⁫⁭⁮‬‮‫‎⁯‫‭⁭⁪‫⁯⁯‬‪⁯‬‭‏‮‭‭‫‌​‪‫‬‮‎⁮⁮⁪⁪‮()
    {
      if ((double) this.\u200B​‫‏⁬⁬‌⁫⁪​⁯‪⁮​⁪‌⁪‫‌⁬⁭​‮⁮‮⁯‪‏‍‮‬‌‏⁪‍⁫⁮‪‍‪‮ - (double) this.\u206E‬‌‬‫​⁫​⁪‌‬⁬​‮‍‎⁯⁭⁭‫‫‮‭‭‫‬‎⁮‫‌​⁭‌⁯⁯‫⁪‪⁪‍‮ < (double) this.impactInterval)
        return;
label_1:
      int num1 = -2119467334;
      float num2;
      while (true)
      {
        uint num3;
        switch ((num3 = (uint) (num1 ^ -621561188)) % 12U)
        {
          case 0:
            this.\u200D​‎‪‪⁯‪​⁯⁬​⁬‪​‍⁭⁭‭‏​‏⁬‪‮⁪‌⁭⁭‫‬​⁭⁪⁮⁮‏‌⁮‫‎‮ = Vector3.get_zero();
            this.\u206D‬⁪⁬⁯‭⁯⁯‬‏⁪‬​‫‫⁮‍⁮⁫‌‬‭‫‎‪⁪​⁪‮⁮‍⁭‍​‫‫‪‮‬⁮‮ = Vector3.get_zero();
            this.\u202C‮‪​‬‮‍‮⁮‪‪⁬‪‬⁬‫⁬‮⁬⁬‏​‏⁭⁭⁯​⁯‏⁮‪⁭‭‮⁯‫‬⁬‍‏‮ = 0;
            this.\u206E‬‌‬‫​⁫​⁪‌‬⁬​‮‍‎⁯⁭⁭‫‫‮‭‭‫‬‎⁮‫‌​⁭‌⁯⁯‫⁪‪⁪‍‮ = this.\u200B​‫‏⁬⁬‌⁫⁪​⁯‪⁮​⁪‌⁪‫‌⁬⁭​‮⁮‮⁯‪‏‍‮‬‌‏⁪‍⁫⁮‪‍‪‮ + this.impactInterval * Random.Range(-this.impactIntervalRandom, this.impactIntervalRandom);
            num1 = (int) num3 * 526982724 ^ 717674700;
            continue;
          case 1:
            num2 = 1f / (float) this.\u206C⁫⁭‭‭⁭⁫⁭‬⁫‏⁮‎‪⁭⁫⁭⁯​‫⁭‍⁫⁪​‎‏‭​‮⁪⁫⁮⁯‮‍‌⁯⁮‍‮;
            this.\u200D​‎‪‪⁯‪​⁯⁬​⁬‪​‍⁭⁭‭‏​‏⁬‪‮⁪‌⁭⁭‫‬​⁭⁪⁮⁮‏‌⁮‫‎‮ = Vector3.op_Multiply(this.\u200D​‎‪‪⁯‪​⁯⁬​⁬‪​‍⁭⁭‭‏​‏⁬‪‮⁪‌⁭⁭‫‬​⁭⁪⁮⁮‏‌⁮‫‎‮, num2);
            num1 = (int) num3 * 253527544 ^ 1870214110;
            continue;
          case 2:
            int num4 = this.\u206C⁫⁭‭‭⁭⁫⁭‬⁫‏⁮‎‪⁭⁫⁭⁯​‫⁭‍⁫⁪​‎‏‭​‮⁪⁫⁮⁯‮‍‌⁯⁮‍‮ > 0 ? 1082317991 : (num4 = 95018014);
            num1 = num4 ^ (int) num3 * 665515571;
            continue;
          case 3:
            this.onImpact();
            VehicleBase.vehicle = (VehicleBase) null;
            num1 = (int) num3 * -1910589814 ^ 2060084775;
            continue;
          case 4:
            goto label_14;
          case 5:
            int num5;
            num1 = num5 = this.showContactGizmos ? -1975401454 : (num5 = -1360970425);
            continue;
          case 6:
            this.\u206D‬⁪⁬⁯‭⁯⁯‬‏⁪‬​‫‫⁮‍⁮⁫‌‬‭‫‎‪⁪​⁪‮⁮‍⁭‍​‫‫‪‮‬⁮‮ = Vector3.op_Multiply(this.\u206D‬⁪⁬⁯‭⁯⁯‬‏⁪‬​‫‫⁮‍⁮⁫‌‬‭‫‎‪⁪​⁪‮⁮‍⁭‍​‫‫‪‮‬⁮‮, num2);
            int num6 = this.onImpact != null ? 12953792 : (num6 = 163598257);
            num1 = num6 ^ (int) num3 * -1874322780;
            continue;
          case 7:
            Debug.DrawLine(((Component) this).get_transform().TransformPoint(this.localImpactPosition), Vector3.op_Addition(((Component) this).get_transform().TransformPoint(this.localImpactPosition), MathUtility.Lin2Log(((Component) this).get_transform().TransformDirection(this.localImpactVelocity))), Color.get_red(), 0.2f, false);
            num1 = (int) num3 * 511678404 ^ -1650275973;
            continue;
          case 8:
            VehicleBase.vehicle = this;
            num1 = (int) num3 * -1250069698 ^ 6972759;
            continue;
          case 9:
            goto label_1;
          case 10:
            Vector3 localImpactVelocity = this.localImpactVelocity;
            int num7 = (double) ((Vector3) ref localImpactVelocity).get_sqrMagnitude() > 9.99999974737875E-05 ? 562440989 : (num7 = 703905337);
            num1 = num7 ^ (int) num3 * 178181577;
            continue;
          case 11:
            this.\u206C⁫⁭‭‭⁭⁫⁭‬⁫‏⁮‎‪⁭⁫⁭⁯​‫⁭‍⁫⁪​‎‏‭​‮⁪⁫⁮⁯‮‍‌⁯⁮‍‮ = 0;
            num1 = -1426246324;
            continue;
          default:
            goto label_15;
        }
      }
label_14:
      return;
label_15:;
    }

    private void OnCollisionEnter(Collision collision) => this.OnCollision(collision, true);

    private void OnCollisionStay(Collision collision) => this.OnCollision(collision, false);

    public void OnCollision(Collision collision, bool isCollisionEnter)
    {
      if (!this.initialized)
        return;
label_1:
      int num1 = 850725059;
      while (true)
      {
        uint num2;
        ContactPoint contactPoint;
        int index;
        Vector3 vector3_1;
        int num3;
        int num4;
        ContactPoint[] contacts;
        int num5;
        float num6;
        Vector3 val;
        float num7;
        Vector3 vector3_2;
        GroundMaterialHit groundHit;
        int num8;
        float num9;
        Vector3 relativeVelocity;
        Vector3 vector3_3;
        float num10;
        Vector3 vector3_4;
        int num11;
        int num12;
        switch ((num2 = (uint) (num1 ^ 99143888)) % 56U)
        {
          case 0:
            contacts = collision.get_contacts();
            index = 0;
            num1 = (int) num2 * 1326524663 ^ -458077887;
            continue;
          case 1:
            num10 = this.impactMinSpeed * this.impactMinSpeed;
            num1 = (int) num2 * -1376377468 ^ -778485844;
            continue;
          case 2:
            vector3_2 = Vector3.op_Addition(vector3_2, ((ContactPoint) ref contactPoint).get_point());
            num1 = (int) num2 * 1808858767 ^ -1330770396;
            continue;
          case 3:
            VehicleBase.vehicle = (VehicleBase) null;
            num1 = (int) num2 * 1151611657 ^ 1526655382;
            continue;
          case 4:
            val = ((ContactPoint) ref contactPoint).get_thisCollider().get_attachedRigidbody().GetPointVelocity(((ContactPoint) ref contactPoint).get_point());
            num1 = 1280995114;
            continue;
          case 5:
            vector3_3 = Vector3.op_Multiply(vector3_3, num9);
            num1 = (int) num2 * 482322825 ^ 1459327050;
            continue;
          case 6:
            int num13 = num5 <= 0 ? -1658056762 : (num13 = -478548048);
            num1 = num13 ^ (int) num2 * 1966293426;
            continue;
          case 7:
            vector3_1 = Vector3.get_zero();
            num1 = (int) num2 * 1316389908 ^ 1721458748;
            continue;
          case 8:
            VehicleBase.vehicle = this;
            VehicleBase.currentCollision = collision;
            VehicleBase.isCollisionEnter = isCollisionEnter;
            this.onRawCollision();
            num1 = (int) num2 * 126673277 ^ -1854883229;
            continue;
          case 9:
            this.groundMaterialManager.GetGroundMaterialCached(this, groundHit, ref this.\u200F‎‬‍‌‫‎‬⁮‮‬‭‫‍⁮⁬‭‮‎‮‪‏‌‏‌‮‏​‌⁫‬‫‏‬​⁯⁯‌‫‍‮, ref this.\u202E‬⁮‭‪​⁬‭‭⁪⁯‎⁫‬‌⁭‏⁮‪⁮‏‎⁬⁭‍​⁫‪​⁭​‎‮‪‭⁭⁬‍‮⁭‮);
            int num14 = this.\u202E‬⁮‭‪​⁬‭‭⁪⁯‎⁫‬‌⁭‏⁮‪⁮‏‎⁬⁭‍​⁫‪​⁭​‎‮‪‭⁭⁬‍‮⁭‮ != null ? 1266435612 : (num14 = 1619094181);
            num1 = num14 ^ (int) num2 * 1437287425;
            continue;
          case 10:
            vector3_4 = Vector3.get_zero();
            num11 = 0;
            num8 = 0;
            num1 = (int) num2 * -952847988 ^ 862242495;
            continue;
          case 11:
            int num15 = this.disableContactProcessing ? -1060100769 : (num15 = -2133740828);
            num1 = num15 ^ (int) num2 * -302637280;
            continue;
          case 12:
            num12 = -1;
            break;
          case 13:
            ++num5;
            num1 = 2024376930;
            continue;
          case 14:
            int num16;
            num1 = num16 = (double) num6 >= (double) this.impactThreeshold ? 1875714093 : (num16 = 1232198181);
            continue;
          case 15:
            this.\u206B‮‌‏‏‌‭⁭‬⁪‬‍⁮⁮⁬‫‫‍‏​⁪⁮‫‬‌‏⁮‫⁫​‎⁬⁬‍‏‬‍⁫⁪‌‮(this.\u200B‏‮‪⁬‪‮‏‫‫‍‏‌‏‪‏⁫⁯‮⁬‫⁪‎‍‭‫​⁯⁯⁫‎‌‏⁯‭⁯⁭‍‪‮‮.InverseTransformPoint(vector3_1), this.\u200B‏‮‪⁬‪‮‏‫‫‍‏‌‏‪‏⁫⁯‮⁬‫⁪‎‍‭‫​⁯⁯⁫‎‌‏⁯‭⁯⁭‍‪‮‮.InverseTransformDirection(vector3_3), num3);
            num1 = (int) num2 * -865049257 ^ 171787752;
            continue;
          case 16:
            groundHit.collider = ((ContactPoint) ref contactPoint).get_otherCollider();
            groundHit.hitPoint = ((ContactPoint) ref contactPoint).get_point();
            num1 = (int) num2 * 1126941126 ^ -1680814927;
            continue;
          case 17:
            num1 = (int) num2 * 1719842309 ^ 1129851779;
            continue;
          case 18:
            vector3_4 = Vector3.op_Addition(vector3_4, collision.get_relativeVelocity());
            num11 += num4;
            num1 = (int) num2 * 1416177872 ^ -1465413433;
            continue;
          case 19:
            Debug.DrawLine(((ContactPoint) ref contactPoint).get_point(), Vector3.op_Addition(((ContactPoint) ref contactPoint).get_point(), MathUtility.Lin2Log(val)), Color.get_cyan());
            num1 = (int) num2 * -680712758 ^ 1204026211;
            continue;
          case 20:
            ++index;
            num1 = 368331198;
            continue;
          case 21:
            int num17;
            num1 = num17 = !this.showContactGizmos ? 355399420 : (num17 = 1901799791);
            continue;
          case 22:
            int num18 = Object.op_Inequality((Object) this.groundMaterialManager, (Object) null) ? -1361124811 : (num18 = -1277746348);
            num1 = num18 ^ (int) num2 * -1447512680;
            continue;
          case 23:
            Debug.DrawLine(((ContactPoint) ref contactPoint).get_point(), Vector3.op_Addition(((ContactPoint) ref contactPoint).get_point(), Vector3.op_Multiply(((ContactPoint) ref contactPoint).get_normal(), 0.25f)), Color.get_yellow());
            num1 = (int) num2 * -297232332 ^ 1975440432;
            continue;
          case 24:
            num9 = 1f / (float) num8;
            num1 = (int) num2 * 407136215 ^ 173334425;
            continue;
          case 25:
            val = Vector3.op_Subtraction(val, ((ContactPoint) ref contactPoint).get_otherCollider().get_attachedRigidbody().GetPointVelocity(((ContactPoint) ref contactPoint).get_point()));
            num1 = (int) num2 * 181494459 ^ -439926648;
            continue;
          case 26:
            num4 = 0;
            num1 = (int) num2 * 1247992483 ^ 1488323096;
            continue;
          case 27:
            num6 = Vector3.Dot(val, ((ContactPoint) ref contactPoint).get_normal());
            num1 = 1519932729;
            continue;
          case 28:
            goto label_1;
          case 29:
            if (this.\u202E‬⁮‭‪​⁬‭‭⁪⁯‎⁫‬‌⁭‏⁮‪⁮‏‎⁬⁭‍​⁫‪​⁭​‎‮‪‭⁭⁬‍‮⁭‮.surfaceType != GroundMaterial.SurfaceType.Hard)
            {
              num1 = (int) num2 * -1561198192 ^ -30372348;
              continue;
            }
            num12 = 1;
            break;
          case 30:
            int num19 = !this.showContactGizmos ? 771935265 : (num19 = 1754694983);
            num1 = num19 ^ (int) num2 * -224849750;
            continue;
          case 31:
            goto label_61;
          case 32:
            contactPoint = contacts[index];
            num1 = 247995723;
            continue;
          case 33:
            vector3_1 = Vector3.op_Multiply(vector3_1, num9);
            num1 = (int) num2 * 231469626 ^ 1746766383;
            continue;
          case 34:
            int num20 = !isCollisionEnter ? 1624858834 : (num20 = 895921179);
            num1 = num20 ^ (int) num2 * -964913334;
            continue;
          case 35:
            this.lastContactedCollider = ((ContactPoint) ref contactPoint).get_otherCollider();
            num1 = (int) num2 * -513066679 ^ -224457887;
            continue;
          case 36:
            num7 = 1f / (float) num5;
            vector3_2 = Vector3.op_Multiply(vector3_2, num7);
            num1 = (int) num2 * 1526079898 ^ -1865172264;
            continue;
          case 37:
            ++num8;
            num1 = (int) num2 * 1955250171 ^ 1595432769;
            continue;
          case 38:
            int num21;
            num1 = num21 = index >= contacts.Length ? 590794854 : (num21 = 1365280560);
            continue;
          case 39:
            int num22 = !this.showContactGizmos ? 1154889168 : (num22 = 1837759074);
            num1 = num22 ^ (int) num2 * -144736149;
            continue;
          case 40:
            vector3_4 = Vector3.op_Multiply(vector3_4, num7);
            ++this.\u206C⁫⁭‭‭⁭⁫⁭‬⁫‏⁮‎‪⁭⁫⁭⁯​‫⁭‍⁫⁪​‎‏‭​‮⁪⁫⁮⁯‮‍‌⁯⁮‍‮;
            this.\u200D​‎‪‪⁯‪​⁯⁬​⁬‪​‍⁭⁭‭‏​‏⁬‪‮⁪‌⁭⁭‫‬​⁭⁪⁮⁮‏‌⁮‫‎‮ = Vector3.op_Addition(this.\u200D​‎‪‪⁯‪​⁯⁬​⁬‪​‍⁭⁭‭‏​‏⁬‪‮⁪‌⁭⁭‫‬​⁭⁪⁮⁮‏‌⁮‫‎‮, this.\u200B‏‮‪⁬‪‮‏‫‫‍‏‌‏‪‏⁫⁯‮⁬‫⁪‎‍‭‫​⁯⁯⁫‎‌‏⁯‭⁯⁭‍‪‮‮.InverseTransformPoint(vector3_2));
            this.\u206D‬⁪⁬⁯‭⁯⁯‬‏⁪‬​‫‫⁮‍⁮⁫‌‬‭‫‎‪⁪​⁪‮⁮‍⁭‍​‫‫‪‮‬⁮‮ = Vector3.op_Addition(this.\u206D‬⁪⁬⁯‭⁯⁯‬‏⁪‬​‫‫⁮‍⁮⁫‌‬‭‫‎‪⁪​⁪‮⁮‍⁭‍​‫‫‪‮‬⁮‮, this.\u200B‏‮‪⁬‪‮‏‫‫‍‏‌‏‪‏⁫⁯‮⁬‫⁪‎‍‭‫​⁯⁯⁫‎‌‏⁯‭⁯⁭‍‪‮‮.InverseTransformDirection(vector3_4));
            this.\u202C‮‪​‬‮‍‮⁮‪‪⁬‪‬⁬‫⁬‮⁬⁬‏​‏⁭⁭⁯​⁯‏⁮‪⁭‭‮⁯‫‬⁬‍‏‮ += num11;
            num1 = (int) num2 * -1906893077 ^ -1384153062;
            continue;
          case 41:
            int num23 = (double) num6 >= -(double) this.impactThreeshold ? 935058730 : (num23 = 1891720925);
            num1 = num23 ^ (int) num2 * 714108808;
            continue;
          case 42:
            int num24;
            num1 = num24 = num8 <= 0 ? 524378073 : (num24 = 1541936648);
            continue;
          case 43:
            VehicleBase.currentCollision = (Collision) null;
            num1 = (int) num2 * 1638038387 ^ -1435779726;
            continue;
          case 44:
            num5 = 0;
            vector3_2 = Vector3.get_zero();
            num1 = 346740706;
            continue;
          case 45:
            groundHit = new GroundMaterialHit();
            groundHit.physicMaterial = ((ContactPoint) ref contactPoint).get_otherCollider().get_sharedMaterial();
            num1 = (int) num2 * 1840088156 ^ 797982588;
            continue;
          case 46:
            vector3_3 = Vector3.op_Addition(vector3_3, val);
            num1 = (int) num2 * -36582810 ^ -908935080;
            continue;
          case 47:
            Debug.DrawLine(((ContactPoint) ref contactPoint).get_point(), Vector3.op_Addition(((ContactPoint) ref contactPoint).get_point(), MathUtility.Lin2Log(val)), Color.get_red());
            num1 = (int) num2 * 1160667623 ^ -1884082332;
            continue;
          case 48:
            vector3_3 = Vector3.get_zero();
            num3 = 0;
            num1 = (int) num2 * 467713152 ^ 221778897;
            continue;
          case 49:
            int num25;
            num1 = num25 = this.onRawCollision == null ? 1375827229 : (num25 = 994550440);
            continue;
          case 50:
            int num26 = !Object.op_Inequality((Object) ((ContactPoint) ref contactPoint).get_otherCollider().get_attachedRigidbody(), (Object) null) ? 1718761245 : (num26 = 128369503);
            num1 = num26 ^ (int) num2 * -497379297;
            continue;
          case 51:
            int num27 = (double) ((Vector3) ref relativeVelocity).get_sqrMagnitude() <= (double) num10 ? 1733181033 : (num27 = 853080282);
            num1 = num27 ^ (int) num2 * -478037499;
            continue;
          case 52:
            num3 += num4;
            num1 = (int) num2 * -1970222039 ^ 1675508994;
            continue;
          case 53:
            goto label_5;
          case 54:
            vector3_1 = Vector3.op_Addition(vector3_1, ((ContactPoint) ref contactPoint).get_point());
            num1 = (int) num2 * -853931948 ^ 1296427270;
            continue;
          case 55:
            relativeVelocity = collision.get_relativeVelocity();
            num1 = (int) num2 * -1795806996 ^ 1592426247;
            continue;
          default:
            goto label_62;
        }
        num4 = num12;
        num1 = 1192699140;
      }
label_61:
      return;
label_5:
      return;
label_62:;
    }

    private void \u206B‮‌‏‏‌‭⁭‬⁪‬‍⁮⁮⁬‫‫‍‏​⁪⁮‫‬‌‏⁮‫⁫​‎⁬⁬‍‏‬‍⁫⁪‌‮(
      Vector3 _param1,
      Vector3 _param2,
      int _param3)
    {
      if ((double) ((Vector3) ref _param2).get_sqrMagnitude() <= 9.99999974737875E-05)
        goto label_8;
label_1:
      int num1 = 1697929606;
label_2:
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ 866037197)) % 10U)
        {
          case 0:
            this.\u200E‏‮⁯⁪⁮‍⁮‫‭‭‭⁫‬⁭⁪⁫⁫‬‮‌⁯‎‬‫​⁫⁪‌⁮‌‭⁯‬⁭‎‮‍‫⁪‮ = _param3;
            num1 = (int) num2 * 29680581 ^ 1466841235;
            continue;
          case 1:
            Debug.DrawLine(((Component) this).get_transform().TransformPoint(this.localDragPosition), Vector3.op_Addition(((Component) this).get_transform().TransformPoint(this.localDragPosition), MathUtility.Lin2Log(((Component) this).get_transform().TransformDirection(this.localDragVelocity))), Color.get_cyan(), 0.05f, false);
            num1 = (int) num2 * -539063190 ^ -725170329;
            continue;
          case 2:
            goto label_8;
          case 3:
            int num3;
            num1 = num3 = !this.showContactGizmos ? 401227505 : (num3 = 1664609372);
            continue;
          case 4:
            goto label_3;
          case 5:
            this.\u200F⁭⁫‍⁪‍⁭‬⁯⁭⁭‫‎​⁭⁬‌⁯⁫⁬‎‎⁮‍⁮⁯‏‏⁫‫‫‮‮⁯⁮‍‏⁪⁪⁯‮ = Vector3.Lerp(this.\u200F⁭⁫‍⁪‍⁭‬⁯⁭⁭‫‎​⁭⁬‌⁯⁫⁬‎‎⁮‍⁮⁯‏‏⁫‫‫‮‮⁯⁮‍‏⁪⁪⁯‮, _param1, 10f * Time.get_deltaTime());
            num1 = (int) num2 * 1287693689 ^ -823157047;
            continue;
          case 6:
            goto label_1;
          case 7:
            this.\u206E⁬‏‪‪‮‭‌⁯⁭⁯⁪⁫⁫​‫‍⁯‫‌‫‭⁮‫‮‫⁭‏‮‮⁪⁮​⁬‏‪‬‮‍‎‮ = Vector3.Lerp(this.\u206E⁬‏‪‪‮‭‌⁯⁭⁯⁪⁫⁫​‫‍⁯‫‌‫‭⁮‫‮‫⁭‏‮‮⁪⁮​⁬‏‪‬‮‍‎‮, _param2, 20f * Time.get_deltaTime());
            num1 = (int) num2 * -1292732512 ^ 522102997;
            continue;
          case 8:
            num1 = (int) num2 * -442940759 ^ 96744766;
            continue;
          case 9:
            Vector3 localDragVelocity = this.localDragVelocity;
            int num4 = (double) ((Vector3) ref localDragVelocity).get_sqrMagnitude() <= 9.99999974737875E-05 ? 1453206951 : (num4 = 1725016164);
            num1 = num4 ^ (int) num2 * -409668874;
            continue;
          default:
            goto label_12;
        }
      }
label_3:
      return;
label_12:
      return;
label_8:
      this.\u206E⁬‏‪‪‮‭‌⁯⁭⁯⁪⁫⁫​‫‍⁯‫‌‫‭⁮‫‮‫⁭‏‮‮⁪⁮​⁬‏‪‬‮‍‎‮ = Vector3.Lerp(this.\u206E⁬‏‪‪‮‭‌⁯⁭⁯⁪⁫⁫​‫‍⁯‫‌‫‭⁮‫‮‫⁭‏‮‮⁪⁮​⁬‏‪‬‮‍‎‮, Vector3.get_zero(), 10f * Time.get_deltaTime());
      num1 = 430891976;
      goto label_2;
    }

    protected VehicleBase() => base.\u002Ector();

    static VehicleBase()
    {
label_1:
      int num1 = -1741042577;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -1172098256)) % 4U)
        {
          case 0:
            goto label_1;
          case 1:
            VehicleBase.isCollisionEnter = false;
            num1 = (int) num2 * 1141356966 ^ -550232372;
            continue;
          case 2:
            goto label_3;
          case 3:
            VehicleBase.currentCollision = (Collision) null;
            num1 = (int) num2 * -453111353 ^ -370321100;
            continue;
          default:
            goto label_6;
        }
      }
label_3:
      return;
label_6:;
    }

    public enum VehicleSleepCriteria
    {
      Strict,
      Relaxed,
    }

    public class WheelState
    {
      public VPWheelCollider wheelCol;
      public bool steerable;
      public float steerAngle;
      public bool grounded;
      public WheelHit hit;
      public GroundMaterial groundMaterial;
      public GroundMaterialHit lastGroundHit;
      public float contactDepth;
      public float suspensionCompression;
      public float downforce;
      public float normalizedLoad;
      public float contactAngle;
      public float contactSpeed;
      public float damperForce;
      public float lastContactDepth;
      public Vector3 wheelVelocity;
      public Vector3 surfaceForce;
      public Vector2 localWheelVelocity;
      public Vector2 localSurfaceForce;
      public Vector2 externalTireForce;
      public float angularVelocity;
      public Vector2 tireForce;
      public float reactionTorque;
      public Vector2 tireSlip;
      public float combinedTireSlip;
      public Vector2 lastTireForce;
      public float driveTorque;
      public float brakeTorque;
    }

    [Serializable]
    public struct VehicleStateVars
    {
      public float time;
      public Vector3 lastVelocity;
      public float lastImpactTime;
    }

    [Serializable]
    public struct WheelStateVars
    {
      public float L;
      public float Tr;
      public float contactDepth;
      public Vector2 lastTireForce;
    }

    public struct BlockState
    {
      public float L;
      public float I;
      public float Tr;
      public float Td;
    }

    public struct SolverState
    {
      public int step;
      public float time;
      public VehicleBase.BlockState[] blockStates;
    }

    public enum WheelPos
    {
      Default = 0,
      Left = 0,
      Right = 99, // 0x00000063
    }
  }
}
*/