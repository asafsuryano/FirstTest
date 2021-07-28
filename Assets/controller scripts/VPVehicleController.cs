// Decompiled with JetBrains decompiler
// Type: VehiclePhysics.VPVehicleController
// Assembly: VehiclePhysics, Version=7.0.7264.31677, Culture=neutral, PublicKeyToken=null
// MVID: BF795726-A0C5-40AB-B959-3B97B61C9CBB
// Assembly location: D:\Sdk\VehiclePhysics.dll
/*
using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace VehiclePhysics
{
  [AddComponentMenu("Vehicle Physics/Vehicle Controller", -21)]
  public class VPVehicleController : VehicleBase
  {
    public Inertia.Settings inertia = new Inertia.Settings();
    public VPAxle[] axles;
    [FormerlySerializedAs("transmission")]
    public Driveline.Settings driveline = new Driveline.Settings();
    public Differential.Settings differential = new Differential.Settings();
    public Differential.Settings centerDifferential = new Differential.Settings();
    public Differential.Settings interAxleDifferential = new Differential.Settings();
    public TorqueSplitter.Settings torqueSplitter = new TorqueSplitter.Settings();
    public Steering.Settings steering = new Steering.Settings();
    public Brakes.Settings brakes = new Brakes.Settings();
    public TireFriction tireFriction = new TireFriction();
    public Engine.Settings engine = new Engine.Settings();
    public Engine.ClutchSettings clutch = new Engine.ClutchSettings();
    public Gearbox.Settings gearbox = new Gearbox.Settings();
    public SteeringAids.Settings steeringAids = new SteeringAids.Settings();
    public SpeedControl.Settings speedControl = new SpeedControl.Settings();
    public Brakes.AbsSettings antiLock = new Brakes.AbsSettings();
    public TractionControl.Settings tractionControl = new TractionControl.Settings();
    public StabilityControl.Settings stabilityControl = new StabilityControl.Settings();
    [FormerlySerializedAs("antiSlip")]
    public AntiSpin.Settings antiSpin = new AntiSpin.Settings();
    [Range(0.0f, 1f)]
    public float engineReactionFactor = 1f;
    [Range(0.0f, 1f)]
    public float parkModeReactionFactor = 0.95f;
    public float maxSubsystemsEnergy = 100000f;
    private Inertia \u202E⁭‌‌​‏‏‬⁮‍‮⁯‌⁮​⁯⁯​‌‭⁪​‪‌‮⁪​⁮⁯‏⁫​‏⁪⁫⁫‏‌‮⁯‮;
    private Steering \u202E⁯⁯⁭⁭‌‎⁭‭‮⁬⁫⁬⁫‭⁭⁪‫‭‌⁮‏‬‭⁪​‎‭‎‏⁬⁮⁯⁪⁮⁮‮​⁪‌‮;
    private Brakes \u200B‭⁭​‌⁬‭⁪‮⁪‪‫‌‌‪‫⁪⁮⁮⁮⁫‭⁪‭⁫‫‏​⁪⁮⁫‍⁫‎⁬‬‬‏‌‌‮;
    private Engine \u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮;
    private Gearbox \u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮;
    private Retarder \u206C⁯‎‪⁭​‎⁭⁪​‏‭⁬‍⁯‏‌‍‪‮⁬⁮‭‬​‎​​‭​‬‎‫⁯​‍​‎‭⁯‮;
    private Driveline \u206C‎‎‬‮⁫​‏⁪⁭⁫⁯‫‌‎‫⁪‍⁪⁭⁬​⁮‌‭⁭‪‭‪‎‏⁯⁫⁮‍⁫‪‌⁬‎‮;
    private StabilityControl \u200E‭‎⁪‬​⁭‫⁭⁪⁯‫‌⁫⁯⁬⁬‎⁫‏⁪⁮⁮⁭‏‌⁪⁫‌‪⁪‫⁬‭‫⁪⁮‬​‫‮;
    private AntiSpin \u206E⁭⁬‍​‭⁭‏‮‎‏⁯⁫‌‌​‮‪‌‍‬‍‌‎‏⁭​‬‏⁪⁬‫⁪⁬‬‪⁪‫⁮⁬‮;
    private EnergyProvider \u206D‌‎‏‭⁭​‎‎​‎‍‫⁭‭⁫⁬⁫⁮⁮‪⁪⁪⁫‫‭⁫‍‏‬‏⁯⁪‬‫⁬⁪‌‍‍‮;
    private int \u202C⁪​‬⁯‬​⁭‪⁪‫‫⁯⁮‮‪‭‮⁮‭‪⁫‎‍⁯⁪⁬‫⁬‏​⁮‎​‏‪‬‏⁪‌‮ = -1;
    private float \u206B⁮⁪‏⁯‮⁬‭‌⁫‏⁬‍‎‭‭‫‌‭‏‍‍⁭‬⁪⁫⁬‮‫‏‏⁭‬‎‬‭​⁫​⁯‮ = 1f;

    private VPVehicleController()
    {
label_1:
      int num1 = 2118550530;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ 1854026209)) % 8U)
        {
          case 0:
            this.torqueSplitter.stiffness = 0.5f;
            num1 = (int) num2 * -2019826915 ^ 1936060368;
            continue;
          case 1:
            goto label_3;
          case 2:
            this.axles[1].brakeCircuit = Brakes.BrakeCircuit.Rear;
            num1 = (int) num2 * -1333301052 ^ 917942325;
            continue;
          case 3:
            this.axles = new VPAxle[2];
            this.axles[0] = new VPAxle();
            this.axles[1] = new VPAxle();
            this.axles[0].steeringMode = Steering.SteeringMode.Steerable;
            this.axles[0].brakeCircuit = Brakes.BrakeCircuit.Front;
            num1 = (int) num2 * -1037273463 ^ -2103678712;
            continue;
          case 4:
            this.centerDifferential.gearRatio = 1f;
            this.centerDifferential.type = Differential.Type.Locked;
            num1 = (int) num2 * -47197822 ^ 1946920684;
            continue;
          case 5:
            this.interAxleDifferential.gearRatio = 1f;
            num1 = (int) num2 * 928776639 ^ 449159941;
            continue;
          case 6:
            goto label_1;
          case 7:
            this.interAxleDifferential.type = Differential.Type.Locked;
            num1 = (int) num2 * 495107322 ^ -1134034665;
            continue;
          default:
            goto label_10;
        }
      }
label_3:
      return;
label_10:;
    }

    protected override void OnInitialize()
    {
      this.SetNumberOfWheels(this.axles.Length * 2);
label_1:
      int num1 = -2146821773;
      int index1;
      bool flag;
      int index2;
      int index3;
      float num2;
      float num3;
      float num4;
      VPWheelCollider leftWheel;
      int index4;
      int length1;
      int index5;
      int index6;
      int index7;
      VPWheelCollider rightWheel;
      int length2;
      int length3;
      while (true)
      {
        uint num5;
        switch ((num5 = (uint) (num1 ^ -1976601127)) % 63U)
        {
          case 0:
            this.\u206B⁮⁪‏⁯‮⁬‭‌⁫‏⁬‍‎‭‭‫‌‭‏‍‍⁭‬⁪⁫⁬‮‫‏‏⁭‬‎‬‭​⁫​⁯‮ = num2 - num3;
            num1 = (int) num5 * 1811906978 ^ 683999662;
            continue;
          case 1:
            this.\u206E⁭⁬‍​‭⁭‏‮‎‏⁯⁫‌‌​‮‪‌‍‬‍‌‎‏⁭​‬‏⁪⁬‫⁪⁬‬‪⁪‫⁮⁬‮ = new AntiSpin();
            num1 = (int) num5 * 457416968 ^ 312813814;
            continue;
          case 2:
            this.\u202E⁭‌‌​‏‏‬⁮‍‮⁯‌⁮​⁯⁯​‌‭⁪​‪‌‮⁪​⁮⁯‏⁫​‏⁪⁫⁫‏‌‮⁯‮ = new Inertia();
            num1 = (int) num5 * 877096485 ^ -1533234161;
            continue;
          case 3:
            int num6;
            num1 = num6 = index4 >= length3 ? -962772257 : (num6 = -371743518);
            continue;
          case 4:
            ++index1;
            num1 = (int) num5 * 1438144498 ^ -673552964;
            continue;
          case 5:
            this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮ = new Engine();
            num1 = (int) num5 * 167637035 ^ 641309791;
            continue;
          case 6:
            this.\u206C‎‎‬‮⁫​‏⁪⁭⁫⁯‫‌‎‫⁪‍⁪⁭⁬​⁮‌‭⁭‪‭‪‎‏⁯⁫⁮‍⁫‪‌⁬‎‮ = new Driveline();
            num1 = (int) num5 * -101569109 ^ 708137099;
            continue;
          case 7:
            index1 = 0;
            num1 = (int) num5 * 1354043443 ^ -2029308685;
            continue;
          case 8:
            this.\u200B‭⁭​‌⁬‭⁪‮⁪‪‫‌‌‪‫⁪⁮⁮⁮⁫‭⁪‭⁫‫‏​⁪⁮⁫‍⁫‎⁬‬‬‏‌‌‮ = new Brakes();
            this.\u200B‭⁭​‌⁬‭⁪‮⁪‪‫‌‌‪‫⁪⁮⁮⁮⁫‭⁪‭⁫‫‏​⁪⁮⁫‍⁫‎⁬‬‬‏‌‌‮.settings = this.brakes;
            this.\u200B‭⁭​‌⁬‭⁪‮⁪‪‫‌‌‪‫⁪⁮⁮⁮⁫‭⁪‭⁫‫‏​⁪⁮⁫‍⁫‎⁬‬‬‏‌‌‮.absSettings = this.antiLock;
            num1 = (int) num5 * -1226788453 ^ 1241203381;
            continue;
          case 9:
            this.DebugLogError(\u003CModule\u003E.\u200C‫⁪⁬‪‫‍‫⁪‫⁮‍⁮⁮‍⁮‮‏⁪⁭‭⁫‭‬⁪⁪⁬‮‍‍⁫‎‌‪⁮‭⁯⁪​⁯‮<string>(949855203U));
            num1 = -122717565;
            continue;
          case 10:
            Block.Connect((Block) this.\u206C⁯‎‪⁭​‎⁭⁪​‏‭⁬‍⁯‏‌‍‪‮⁬⁮‭‬​‎​​‭​‬‎‫⁯​‍​‎‭⁯‮, 0, (Block) this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮, 0);
            this.\u206C‎‎‬‮⁫​‏⁪⁭⁫⁯‫‌‎‫⁪‍⁪⁭⁬​⁮‌‭⁭‪‭‪‎‏⁯⁫⁮‍⁫‪‌⁬‎‮.settings = this.driveline;
            this.\u206C‎‎‬‮⁫​‏⁪⁭⁫⁯‫‌‎‫⁪‍⁪⁭⁬​⁮‌‭⁭‪‭‪‎‏⁯⁫⁮‍⁫‪‌⁬‎‮.axleDifferential = this.differential;
            this.\u206C‎‎‬‮⁫​‏⁪⁭⁫⁯‫‌‎‫⁪‍⁪⁭⁬​⁮‌‭⁭‪‭‪‎‏⁯⁫⁮‍⁫‪‌⁬‎‮.centerDifferential = this.centerDifferential;
            this.\u206C‎‎‬‮⁫​‏⁪⁭⁫⁯‫‌‎‫⁪‍⁪⁭⁬​⁮‌‭⁭‪‭‪‎‏⁯⁫⁮‍⁫‪‌⁬‎‮.interAxleDifferential = this.interAxleDifferential;
            num1 = (int) num5 * -655809210 ^ 2020357265;
            continue;
          case 11:
            num1 = (int) num5 * -1977743850 ^ 1357558468;
            continue;
          case 12:
            length2 = this.axles.Length;
            num1 = (int) num5 * 1092439409 ^ -2012742870;
            continue;
          case 13:
            length3 = this.axles.Length;
            num1 = (int) num5 * 213634945 ^ -2039603802;
            continue;
          case 14:
            this.\u202C⁪​‬⁯‬​⁭‪⁪‫‫⁯⁮‮‪‭‮⁮‭‪⁫‎‍⁯⁪⁬‫⁬‏​⁮‎​‏‪‬‏⁪‌‮ = -1;
            num1 = (int) num5 * 503673431 ^ 1892250044;
            continue;
          case 15:
            this.\u200B‭⁭​‌⁬‭⁪‮⁪‪‫‌‌‪‫⁪⁮⁮⁮⁫‭⁪‭⁫‫‏​⁪⁮⁫‍⁫‎⁬‬‬‏‌‌‮.AddWheel(this.wheelState[index5], this.wheels[index5], this.axles[index2].brakeCircuit, Brakes.LateralPosition.Left);
            this.\u200B‭⁭​‌⁬‭⁪‮⁪‪‫‌‌‪‫⁪⁮⁮⁮⁫‭⁪‭⁫‫‏​⁪⁮⁫‍⁫‎⁬‬‬‏‌‌‮.AddWheel(this.wheelState[index3], this.wheels[index3], this.axles[index2].brakeCircuit, Brakes.LateralPosition.Right);
            ++index2;
            num1 = -1117546372;
            continue;
          case 16:
            ++index4;
            num1 = -526648028;
            continue;
          case 17:
            this.\u202C⁪​‬⁯‬​⁭‪⁪‫‫⁯⁮‮‪‭‮⁮‭‪⁫‎‍⁯⁪⁬‫⁬‏​⁮‎​‏‪‬‏⁪‌‮ = index2;
            num1 = (int) num5 * -1932695065 ^ -1205366107;
            continue;
          case 18:
            this.\u206E⁭⁬‍​‭⁭‏‮‎‏⁯⁫‌‌​‮‪‌‍‬‍‌‎‏⁭​‬‏⁪⁬‫⁪⁬‬‪⁪‫⁮⁬‮.settings = this.antiSpin;
            num1 = (int) num5 * -980800543 ^ 136064077;
            continue;
          case 19:
            this.\u206C‎‎‬‮⁫​‏⁪⁭⁫⁯‫‌‎‫⁪‍⁪⁭⁬​⁮‌‭⁭‪‭‪‎‏⁯⁫⁮‍⁫‪‌⁬‎‮.torqueSplitter = this.torqueSplitter;
            num1 = (int) num5 * 571320936 ^ -1146353848;
            continue;
          case 20:
            this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.settings = this.engine;
            this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.clutchSettings = this.clutch;
            num1 = (int) num5 * 1742006856 ^ 49764893;
            continue;
          case 21:
            index6 = index1 * 2;
            num1 = -527947411;
            continue;
          case 22:
            this.\u206C⁯‎‪⁭​‎⁭⁪​‏‭⁬‍⁯‏‌‍‪‮⁬⁮‭‬​‎​​‭​‬‎‫⁯​‍​‎‭⁯‮ = new Retarder();
            num1 = (int) num5 * 23475449 ^ -1082797065;
            continue;
          case 23:
            int num7 = this.\u202C⁪​‬⁯‬​⁭‪⁪‫‫⁯⁮‮‪‭‮⁮‭‪⁫‎‍⁯⁪⁬‫⁬‏​⁮‎​‏‪‬‏⁪‌‮ != -1 ? 1876026033 : (num7 = 1072814357);
            num1 = num7 ^ (int) num5 * 2079878876;
            continue;
          case 24:
            this.\u206D‌‎‏‭⁭​‎‎​‎‍‫⁭‭⁫⁬⁫⁮⁮‪⁪⁪⁫‫‭⁫‍‏‬‏⁯⁪‬‫⁬⁪‌‍‍‮ = new EnergyProvider(this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮);
            num1 = (int) num5 * 1664447185 ^ -90191873;
            continue;
          case 25:
            index3 = index2 * 2 + 1;
            num1 = (int) num5 * 1772382435 ^ -1831829460;
            continue;
          case 26:
            this.\u202E⁯⁯⁭⁭‌‎⁭‭‮⁬⁫⁬⁫‭⁭⁪‫‭‌⁮‏‬‭⁪​‎‭‎‏⁬⁮⁯⁪⁮⁮‮​⁪‌‮.AddWheel(this.wheelState[index3], this.GetWheelLocalPosition(this.wheelState[index3].wheelCol), this.axles[index2].steeringMode, this.axles[index2].steeringRatio);
            num1 = (int) num5 * -987700522 ^ -1636821257;
            continue;
          case 27:
            this.\u202E⁯⁯⁭⁭‌‎⁭‭‮⁬⁫⁬⁫‭⁭⁪‫‭‌⁮‏‬‭⁪​‎‭‎‏⁬⁮⁯⁪⁮⁮‮​⁪‌‮.settings = this.steering;
            num1 = (int) num5 * 1525360340 ^ 582949083;
            continue;
          case 28:
            int num8 = this.axles[index2].steeringMode == Steering.SteeringMode.Disabled ? 456262884 : (num8 = 1157270943);
            num1 = num8 ^ (int) num5 * 1085230015;
            continue;
          case 29:
            this.\u202E⁯⁯⁭⁭‌‎⁭‭‮⁬⁫⁬⁫‭⁭⁪‫‭‌⁮‏‬‭⁪​‎‭‎‏⁬⁮⁯⁪⁮⁮‮​⁪‌‮.AddWheel(this.wheelState[index5], this.GetWheelLocalPosition(this.wheelState[index5].wheelCol), this.axles[index2].steeringMode, this.axles[index2].steeringRatio);
            num1 = (int) num5 * -510487105 ^ 457876334;
            continue;
          case 30:
            index4 = 0;
            num1 = (int) num5 * -619135864 ^ 2071098958;
            continue;
          case 31:
            this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮ = new Gearbox();
            this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.settings = this.gearbox;
            this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.signalSwitchingGears = new Action(this.\u202C⁭‪⁬​⁮⁬‍⁯⁬⁫‎⁭​​⁮‪‭‏‬‏‮⁪⁬⁬⁮‌‭⁭‬⁭​‫‮⁯​​⁭‍⁭‮);
            Block.Connect((Block) this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮, 0, (Block) this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮, 0);
            num1 = (int) num5 * 2007763337 ^ -399502583;
            continue;
          case 32:
            this.\u206C⁯‎‪⁭​‎⁭⁪​‏‭⁬‍⁯‏‌‍‪‮⁬⁮‭‬​‎​​‭​‬‎‫⁯​‍​‎‭⁯‮ = (Retarder) null;
            this.\u206D‌‎‏‭⁭​‎‎​‎‍‫⁭‭⁫⁬⁫⁮⁮‪⁪⁪⁫‫‭⁫‍‏‬‏⁯⁪‬‫⁬⁪‌‍‍‮ = (EnergyProvider) null;
            num1 = (int) num5 * -1071303027 ^ -38353013;
            continue;
          case 33:
            goto label_24;
          case 34:
            flag = (uint) this.axles[index1].steeringMode > 0U;
            num1 = (int) num5 * -1796174161 ^ -1440769263;
            continue;
          case 35:
            num3 = num4;
            num1 = (int) num5 * -1461418210 ^ 2084825144;
            continue;
          case 36:
            index5 = index2 * 2;
            num1 = -1788037253;
            continue;
          case 37:
            num1 = (int) num5 * -316796871 ^ 1511355015;
            continue;
          case 38:
            goto label_1;
          case 39:
            this.wheelState[index6].steerable = flag;
            this.wheelState[index7].steerable = flag;
            Wheel wheel1 = this.wheels[index6];
            wheel1.tireFriction = this.tireFriction;
            wheel1.radius = leftWheel.radius;
            wheel1.mass = leftWheel.mass;
            Wheel wheel2 = this.wheels[index7];
            wheel2.tireFriction = this.tireFriction;
            wheel2.radius = rightWheel.radius;
            wheel2.mass = rightWheel.mass;
            num1 = (int) num5 * 645525188 ^ 142881153;
            continue;
          case 40:
            int num9;
            num1 = num9 = index1 < length2 ? -1605354228 : (num9 = -282246592);
            continue;
          case 41:
            num1 = (int) num5 * -1248976444 ^ 1341136896;
            continue;
          case 42:
            this.\u206C‎‎‬‮⁫​‏⁪⁭⁫⁯‫‌‎‫⁪‍⁪⁭⁬​⁮‌‭⁭‪‭‪‎‏⁯⁫⁮‍⁫‪‌⁬‎‮.SetupDriveline(this.wheels, (Block) this.\u206C⁯‎‪⁭​‎⁭⁪​‏‭⁬‍⁯‏‌‍‪‮⁬⁮‭‬​‎​​‭​‬‎‫⁯​‍​‎‭⁯‮);
            num1 = (int) num5 * 161948474 ^ -97490438;
            continue;
          case 43:
            this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮ = (Gearbox) null;
            num1 = (int) num5 * -1827545022 ^ -1254485968;
            continue;
          case 44:
            goto label_3;
          case 45:
            int num10 = !Object.op_Equality((Object) leftWheel, (Object) null) ? 6133641 : (num10 = 465121929);
            num1 = num10 ^ (int) num5 * -745155095;
            continue;
          case 46:
            this.wheelState[index6].wheelCol = leftWheel;
            this.wheelState[index7].wheelCol = rightWheel;
            num1 = (int) num5 * 194722900 ^ 584354287;
            continue;
          case 47:
            num2 = num4;
            num1 = (int) num5 * -1107770512 ^ -369606531;
            continue;
          case 48:
            num4 = (float) (0.5 * (this.cachedTransform.InverseTransformPoint(((Component) this.axles[index4].leftWheel).get_transform().get_position()).z + this.cachedTransform.InverseTransformPoint(((Component) this.axles[index4].rightWheel).get_transform().get_position()).z));
            int num11;
            num1 = num11 = (double) num4 <= (double) num2 ? -2100708915 : (num11 = -455882652);
            continue;
          case 49:
            this.\u200E‭‎⁪‬​⁭‫⁭⁪⁯‫‌⁫⁯⁬⁬‎⁫‏⁪⁮⁮⁭‏‌⁪⁫‌‪⁪‫⁬‭‫⁪⁮‬​‫‮.settings = this.stabilityControl;
            this.\u200E‭‎⁪‬​⁭‫⁭⁪⁯‫‌⁫⁯⁬⁬‎⁫‏⁪⁮⁮⁭‏‌⁪⁫‌‪⁪‫⁬‭‫⁪⁮‬​‫‮.wheelbase = this.\u206B⁮⁪‏⁯‮⁬‭‌⁫‏⁬‍‎‭‭‫‌‭‏‍‍⁭‬⁪⁫⁬‮‫‏‏⁭‬‎‬‭​⁫​⁯‮;
            num1 = (int) num5 * 488227131 ^ 1728698979;
            continue;
          case 50:
            index7 = index1 * 2 + 1;
            num1 = (int) num5 * -573468764 ^ 980181435;
            continue;
          case 51:
            int num12;
            num1 = num12 = (double) num4 < (double) num3 ? -1521476190 : (num12 = -86969518);
            continue;
          case 52:
            index2 = 0;
            num1 = (int) num5 * 1825109054 ^ 1107869653;
            continue;
          case 53:
            int num13;
            num1 = num13 = index2 < length1 ? -1103547778 : (num13 = -769797766);
            continue;
          case 54:
            int num14 = !Object.op_Equality((Object) rightWheel, (Object) null) ? 737122225 : (num14 = 1684693879);
            num1 = num14 ^ (int) num5 * -788606170;
            continue;
          case 55:
            leftWheel = this.axles[index1].leftWheel;
            rightWheel = this.axles[index1].rightWheel;
            num1 = -1407564549;
            continue;
          case 56:
            int num15 = this.driveline.drivenAxles != Driveline.DrivenAxles.None ? -464510547 : (num15 = -1031188102);
            num1 = num15 ^ (int) num5 * 1219050732;
            continue;
          case 57:
            this.\u202E⁯⁯⁭⁭‌‎⁭‭‮⁬⁫⁬⁫‭⁭⁪‫‭‌⁮‏‬‭⁪​‎‭‎‏⁬⁮⁯⁪⁮⁮‮​⁪‌‮ = new Steering();
            num1 = (int) num5 * -213360549 ^ 1929792805;
            continue;
          case 58:
            num3 = 0.0f;
            num2 = 0.0f;
            num1 = -315437250;
            continue;
          case 59:
            this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮ = (Engine) null;
            num1 = -171346018;
            continue;
          case 60:
            length1 = this.axles.Length;
            num1 = (int) num5 * -911173414 ^ 1212895408;
            continue;
          case 61:
            this.\u200E‭‎⁪‬​⁭‫⁭⁪⁯‫‌⁫⁯⁬⁬‎⁫‏⁪⁮⁮⁭‏‌⁪⁫‌‪⁪‫⁬‭‫⁪⁮‬​‫‮ = new StabilityControl();
            num1 = (int) num5 * -1702563100 ^ 113205111;
            continue;
          case 62:
            this.\u202E⁭‌‌​‏‏‬⁮‍‮⁯‌⁮​⁯⁯​‌‭⁪​‪‌‮⁪​⁮⁯‏⁫​‏⁪⁫⁫‏‌‮⁯‮.settings = this.inertia;
            this.\u202E⁭‌‌​‏‏‬⁮‍‮⁯‌⁮​⁯⁯​‌‭⁪​‪‌‮⁪​⁮⁯‏⁫​‏⁪⁫⁫‏‌‮⁯‮.Apply(this.cachedRigidbody);
            num1 = (int) num5 * -2118553019 ^ 823275397;
            continue;
          default:
            goto label_65;
        }
      }
label_24:
      return;
label_3:
      return;
label_65:;
    }

    protected override void DoUpdateBlocks()
    {
      int[] numArray1 = this.data.Get(0);
      float num1 = (float) numArray1[2] / 10000f;
      float num2 = (float) numArray1[3] / 10000f;
      float num3 = (float) numArray1[1] / 10000f;
      float num4 = (float) numArray1[4] / 10000f;
      float num5 = (float) numArray1[0] / 10000f;
      int num6 = numArray1[8];
      int num7 = numArray1[5];
      int num8 = numArray1[6];
      int num9 = numArray1[7];
      int num10 = numArray1[9];
      int[] numArray2 = this.data.Get(2);
label_1:
      int num11 = 1478538239;
      int num12;
      while (true)
      {
        uint num13;
        switch ((num13 = (uint) (num11 ^ 1324647120)) % 41U)
        {
          case 0:
            this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.stateVehicleBrakes = Mathf.Max(num1, num2);
            num11 = (int) num13 * 1193658442 ^ -1754795104;
            continue;
          case 1:
            this.\u202E⁭‌‌​‏‏‬⁮‍‮⁯‌⁮​⁯⁯​‌‭⁪​‪‌‮⁪​⁮⁯‏⁫​‏⁪⁫⁫‏‌‮⁯‮.DoUpdate(this.cachedRigidbody);
            num11 = 1100874969;
            continue;
          case 2:
            this.\u206C‎‎‬‮⁫​‏⁪⁭⁫⁯‫‌‎‫⁪‍⁪⁭⁬​⁮‌‭⁭‪‭‪‎‏⁯⁫⁮‍⁫‪‌⁬‎‮.drivelineOverride = (Driveline.Override) numArray2[1];
            num11 = 1657374830;
            continue;
          case 3:
            this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.manualGearInput = num7;
            this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.automaticGearInput = num8;
            num11 = (int) num13 * -369160652 ^ -1143195137;
            continue;
          case 4:
            this.\u200B‭⁭​‌⁬‭⁪‮⁪‪‫‌‌‪‫⁪⁮⁮⁮⁫‭⁪‭⁫‫‏​⁪⁮⁫‍⁫‎⁬‬‬‏‌‌‮.absOverride = (Brakes.AbsOverride) numArray2[3];
            num11 = (int) num13 * -936728544 ^ 218984120;
            continue;
          case 5:
            int num14 = this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮ != null ? -967483004 : (num14 = -352922179);
            num11 = num14 ^ (int) num13 * 1249195262;
            continue;
          case 6:
            int num15 = !this.tractionControl.enabled ? -1127264995 : (num15 = -1692345307);
            num11 = num15 ^ (int) num13 * 1975293059;
            continue;
          case 7:
            this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.gearShiftInput = num9;
            this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.stateVehicleSpeed = this.speed;
            num11 = (int) num13 * 1046663972 ^ 1536119757;
            continue;
          case 8:
            num11 = (int) num13 * 1420561582 ^ 1677544272;
            continue;
          case 9:
            this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.ignitionInput = num10;
            num11 = (int) num13 * 1404314162 ^ 1110524264;
            continue;
          case 10:
            this.\u200E‍‪‏⁫⁬‮‬⁮⁬‮‍⁫‬‎‭‍‪⁯⁬‎⁪‍⁭‌⁪‫‪‌‫‌⁮‬⁬⁯⁮‫‫‭‭‮();
            num11 = 177967130;
            continue;
          case 11:
            this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.damping = this.engineReactionFactor;
            num11 = (int) num13 * -1802109582 ^ 1094327805;
            continue;
          case 12:
            goto label_3;
          case 13:
            num12 = numArray2[5];
            num11 = (int) num13 * -2061802903 ^ 1962898616;
            continue;
          case 14:
            this.\u200B‭⁭​‌⁬‭⁪‮⁪‪‫‌‌‪‫⁪⁮⁮⁮⁫‭⁪‭⁫‫‏​⁪⁮⁫‍⁫‎⁬‬‬‏‌‌‮.DoUpdate();
            num11 = (int) num13 * -541321942 ^ -488679536;
            continue;
          case 15:
            num3 = this.\u202B⁮⁯⁫‪⁫‎‎‎‫⁭⁯‎⁪⁮‎⁬‬‪‌⁪⁭⁬‬‭⁪‬⁭‎‪‮‎⁯‫‬⁪‪‍⁯⁮‮(num3);
            num11 = (int) num13 * -313704804 ^ 1279289741;
            continue;
          case 16:
            this.\u202E​‫‪⁬⁪⁯‭⁫‬‍‪⁪⁬⁮‏​‬‭‫‏‫‪⁯⁫⁭⁬⁪⁯⁪‌⁭‮‪‎⁪‮‏⁭⁫‮();
            num11 = (int) num13 * 1749187000 ^ 1233172865;
            continue;
          case 17:
            int num16;
            num11 = num16 = numArray2[7] == 2 ? 1236849197 : (num16 = 782824533);
            continue;
          case 18:
            this.\u206D‌‎‏‭⁭​‎‎​‎‍‫⁭‭⁫⁬⁫⁮⁮‪⁪⁪⁫‫‭⁫‍‏‬‏⁯⁪‬‫⁬⁪‌‍‍‮.maxEnergy = this.maxSubsystemsEnergy;
            this.\u206D‌‎‏‭⁭​‎‎​‎‍‫⁭‭⁫⁬⁫⁮⁮‪⁪⁪⁫‫‭⁫‍‏‬‏⁯⁪‬‫⁬⁪‌‍‍‮.DoUpdate();
            num11 = (int) num13 * -944695605 ^ 903772440;
            continue;
          case 19:
            int num17 = this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮ == null ? 188810452 : (num17 = 2012832983);
            num11 = num17 ^ (int) num13 * 955915419;
            continue;
          case 20:
            int num18;
            num11 = num18 = this.\u206D‌‎‏‭⁭​‎‎​‎‍‫⁭‭⁫⁬⁫⁮⁮‪⁪⁪⁫‫‭⁫‍‏‬‏⁯⁪‬‫⁬⁪‌‍‍‮ == null ? 862597730 : (num18 = 360299518);
            continue;
          case 21:
            this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.throttleInput = num3;
            this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.clutchInput = num4;
            num11 = 813713573;
            continue;
          case 22:
            int num19 = num12 == 2 ? -1739165402 : (num19 = -227601192);
            num11 = num19 ^ (int) num13 * 547887744;
            continue;
          case 23:
            int num20 = this.\u200B‭⁭​‌⁬‭⁪‮⁪‪‫‌‌‪‫⁪⁮⁮⁮⁫‭⁪‭⁫‫‏​⁪⁮⁫‍⁫‎⁬‬‬‏‌‌‮.sensorAbsEngaged ? -74646750 : (num20 = -1241485895);
            num11 = num20 ^ (int) num13 * -769180368;
            continue;
          case 24:
            num11 = (int) num13 * -1631831165 ^ 153127614;
            continue;
          case 25:
            int num21;
            num11 = num21 = num12 != 1 ? 487364294 : (num21 = 1626916824);
            continue;
          case 26:
            goto label_1;
          case 27:
            this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.stateVehicleThrottle = num3;
            num11 = (int) num13 * -1363895851 ^ -1033797290;
            continue;
          case 28:
            this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.tcsRatio = 0.0f;
            num11 = 530817504;
            continue;
          case 29:
            this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.damping = this.parkModeReactionFactor;
            num11 = (int) num13 * 1086635612 ^ 1778684573;
            continue;
          case 30:
            this.\u206C‎‎‬‮⁫​‏⁪⁭⁫⁯‫‌‎‫⁪‍⁪⁭⁬​⁮‌‭⁭‪‭‪‎‏⁯⁫⁮‍⁫‪‌⁬‎‮.differentialOverride = (Driveline.Override) numArray2[0];
            num11 = (int) num13 * -1584798724 ^ -2126409251;
            continue;
          case 31:
            int num22 = this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮ == null ? -1337890845 : (num22 = -1911870147);
            num11 = num22 ^ (int) num13 * 599306086;
            continue;
          case 32:
            this.\u202E⁯⁯⁭⁭‌‎⁭‭‮⁬⁫⁬⁫‭⁭⁪‫‭‌⁮‏‬‭⁪​‎‭‎‏⁬⁮⁯⁪⁮⁮‮​⁪‌‮.steerInput = num5;
            this.\u202E⁯⁯⁭⁭‌‎⁭‭‮⁬⁫⁬⁫‭⁭⁪‫‭‌⁮‏‬‭⁪​‎‭‎‏⁬⁮⁯⁪⁮⁮‮​⁪‌‮.DoUpdate();
            this.\u206A⁭⁭⁭⁮‏‫‮⁭⁬⁭‍‌⁭‬‪‪‮‍⁮⁯‬‫‪‭‎‫⁭‬‌‭⁪​‫‏‬‬‫⁫‬‮();
            num11 = 154185810;
            continue;
          case 33:
            this.\u200B‭⁭​‌⁬‭⁪‮⁪‪‫‌‌‪‫⁪⁮⁮⁮⁫‭⁪‭⁫‫‏​⁪⁮⁫‍⁫‎⁬‬‬‏‌‌‮.brakeInput = num1;
            this.\u200B‭⁭​‌⁬‭⁪‮⁪‪‫‌‌‪‫⁪⁮⁮⁮⁫‭⁪‭⁫‫‏​⁪⁮⁫‍⁫‎⁬‬‬‏‌‌‮.handbrakeInput = num2;
            num11 = 1173348572;
            continue;
          case 34:
            int num23;
            num11 = num23 = this.\u206C⁯‎‪⁭​‎⁭⁪​‏‭⁬‍⁯‏‌‍‪‮⁬⁮‭‬​‎​​‭​‬‎‫⁯​‍​‎‭⁯‮ != null ? 1280445584 : (num23 = 243092021);
            continue;
          case 35:
            this.\u206C⁯‎‪⁭​‎⁭⁪​‏‭⁬‍⁯‏‌‍‪‮⁬⁮‭‬​‎​​‭​‬‎‫⁯​‍​‎‭⁯‮.retarderInput = num6;
            num11 = (int) num13 * 466268209 ^ 206598261;
            continue;
          case 36:
            this.\u200D‮‏‮⁬​​⁭‭⁭⁮⁫‎‬‍‭‭‌⁯‫‬‏‮‭‌‪⁪⁯⁪‍‭‎​‫⁭‎‏⁯‪‬‮(ref num5);
            num11 = (int) num13 * 1831778884 ^ -97857671;
            continue;
          case 37:
            this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.autoShiftOverride = (Gearbox.AutoShiftOverride) numArray2[2];
            num11 = (int) num13 * 1071459849 ^ 1830979035;
            continue;
          case 38:
            this.\u206C‎‎‬‮⁫​‏⁪⁭⁫⁯‫‌‎‫⁪‍⁪⁭⁬​⁮‌‭⁭‪‭‪‎‏⁯⁫⁮‍⁫‪‌⁬‎‮.drivelineOverride = Driveline.Override.ForceUnlocked;
            num11 = (int) num13 * -1571795945 ^ 1274526663;
            continue;
          case 39:
            this.\u200E‭‎⁪‬​⁭‫⁭⁪⁯‫‌⁫⁯⁬⁬‎⁫‏⁪⁮⁮⁭‏‌⁪⁫‌‪⁪‫⁬‭‫⁪⁮‬​‫‮.escOverride = (StabilityControl.Override) numArray2[4];
            this.\u206E⁭⁬‍​‭⁭‏‮‎‏⁯⁫‌‌​‮‪‌‍‬‍‌‎‏⁭​‬‏⁪⁬‫⁪⁬‬‪⁪‫⁮⁬‮.asrOverride = (AntiSpin.Override) numArray2[6];
            num11 = 328919161;
            continue;
          case 40:
            int num24;
            num11 = num24 = this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮ != null ? 1764359866 : (num24 = 2104575981);
            continue;
          default:
            goto label_43;
        }
      }
label_3:
      return;
label_43:;
    }

    protected override void DoUpdateData()
    {
      int[] numArray1 = this.data.Get(1);
label_1:
      int num1 = -856930600;
      int[] numArray2;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -1912674794)) % 25U)
        {
          case 0:
            numArray1[15] = (int) ((double) this.\u206C⁯‎‪⁭​‎⁭⁪​‏‭⁬‍⁯‏‌‍‪‮⁬⁮‭‬​‎​​‭​‬‎‫⁯​‍​‎‭⁯‮.sensorRetarderTorque * 1000.0);
            num1 = (int) num2 * -774196430 ^ -1605615983;
            continue;
          case 1:
            numArray2[7] = this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.gearShiftInput;
            numArray2[5] = this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.manualGearInput;
            num1 = (int) num2 * -121613307 ^ -1444643069;
            continue;
          case 2:
            numArray1[6] = (double) this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.sensorLoad < 0.0 ? -1 : (int) ((double) this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.sensorLoad * 1000.0);
            num1 = -1660085395;
            continue;
          case 3:
            goto label_1;
          case 4:
            numArray1[0] = (int) ((double) this.speed * 1000.0);
            int num3 = this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮ == null ? 2000691221 : (num3 = 1249394480);
            num1 = num3 ^ (int) num2 * 1639833299;
            continue;
          case 5:
            numArray1[18] = this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.sensorTcsEngaged ? 1 : 0;
            num1 = -123531809;
            continue;
          case 6:
            int num4;
            num1 = num4 = this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮ != null ? -52477860 : (num4 = -1636438637);
            continue;
          case 7:
            int num5;
            num1 = num5 = this.\u206C⁯‎‪⁭​‎⁭⁪​‏‭⁬‍⁯‏‌‍‪‮⁬⁮‭‬​‎​​‭​‬‎‫⁯​‍​‎‭⁯‮ == null ? -1544715489 : (num5 = -383512247);
            continue;
          case 8:
            int num6 = this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮ != null ? -906141942 : (num6 = -2081540983);
            num1 = num6 ^ (int) num2 * 1235402596;
            continue;
          case 9:
            numArray1[12] = this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.sensorEngagedGear;
            num1 = (int) num2 * 1572467637 ^ 453909919;
            continue;
          case 10:
            numArray1[17] = this.\u200B‭⁭​‌⁬‭⁪‮⁪‪‫‌‌‪‫⁪⁮⁮⁮⁫‭⁪‭⁫‫‏​⁪⁮⁫‍⁫‎⁬‬‬‏‌‌‮.sensorAbsEngaged ? 1 : 0;
            numArray1[19] = this.\u200E‭‎⁪‬​⁭‫⁭⁪⁯‫‌⁫⁯⁬⁬‎⁫‏⁪⁮⁮⁭‏‌⁪⁫‌‪⁪‫⁬‭‫⁪⁮‬​‫‮.sensorEngaged ? 1 : 0;
            numArray1[20] = this.\u206E⁭⁬‍​‭⁭‏‮‎‏⁯⁫‌‌​‮‪‌‍‬‍‌‎‏⁭​‬‏⁪⁬‫⁪⁬‬‪⁪‫⁮⁬‮.sensorEngaged ? 1 : 0;
            num1 = -971330796;
            continue;
          case 11:
            numArray1[3] = this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.sensorWorking ? 1 : 0;
            numArray1[4] = this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.sensorStarting ? 1 : 0;
            numArray1[5] = this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.sensorRpmLimiter ? 1 : 0;
            numArray1[7] = (int) ((double) this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.sensorFlywheelTorque * 1000.0);
            num1 = -284052135;
            continue;
          case 12:
            numArray2[6] = this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.automaticGearInput;
            num1 = (int) num2 * 1316284332 ^ -411213787;
            continue;
          case 13:
            numArray1[1] = (int) ((double) this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.sensorRpm * 1000.0);
            numArray1[2] = this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.sensorStalled ? 1 : 0;
            num1 = -1347399150;
            continue;
          case 14:
            numArray2[8] = this.\u206C⁯‎‪⁭​‎⁭⁪​‏‭⁬‍⁯‏‌‍‪‮⁬⁮‭‬​‎​​‭​‬‎‫⁯​‍​‎‭⁯‮.retarderInput;
            num1 = (int) num2 * 207446963 ^ -90802101;
            continue;
          case 15:
            numArray1[10] = (int) ((double) this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.sensorOutputTorque * 1000.0);
            num1 = (int) num2 * -2032091438 ^ -1851591522;
            continue;
          case 16:
            numArray1[13] = this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.sensorGearMode;
            num1 = (int) num2 * -1602647654 ^ 2105247201;
            continue;
          case 17:
            numArray1[16] = (int) ((double) this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.sensorOutputRpm * 1000.0);
            num1 = (int) num2 * -713311364 ^ -1953071225;
            continue;
          case 18:
            numArray1[14] = this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.sensorSwitchingGears ? 1 : 0;
            num1 = -722908403;
            continue;
          case 19:
            numArray1[11] = (int) ((double) this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.sensorClutchLock * 1000.0);
            num1 = (int) num2 * 1738750912 ^ -1759614482;
            continue;
          case 20:
            numArray1[9] = (int) ((double) this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.sensorFuelRate * 1000.0);
            num1 = (int) num2 * -474829137 ^ 1457503270;
            continue;
          case 21:
            int num7;
            num1 = num7 = this.\u206C⁯‎‪⁭​‎⁭⁪​‏‭⁬‍⁯‏‌‍‪‮⁬⁮‭‬​‎​​‭​‬‎‫⁯​‍​‎‭⁯‮ != null ? -101134930 : (num7 = -7945757);
            continue;
          case 22:
            numArray1[21] = (int) ((double) this.\u202E⁯⁯⁭⁭‌‎⁭‭‮⁬⁫⁬⁫‭⁭⁪‫‭‌⁮‏‬‭⁪​‎‭‎‏⁬⁮⁯⁪⁮⁮‮​⁪‌‮.steerInput * 10000.0);
            numArray2 = this.data.Get(0);
            num1 = (int) num2 * 1422660943 ^ -830911760;
            continue;
          case 23:
            goto label_3;
          case 24:
            numArray1[8] = (int) ((double) this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.sensorPower * 1000.0);
            num1 = (int) num2 * 478713761 ^ -604085053;
            continue;
          default:
            goto label_27;
        }
      }
label_3:
      return;
label_27:;
    }

    private void \u202C⁭‪⁬​⁮⁬‍⁯⁬⁫‎⁭​​⁮‪‭‏‬‏‮⁪⁬⁬⁮‌‭⁭‬⁭​‫‮⁯​​⁭‍⁭‮()
    {
      if (this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.settings.type != Gearbox.Type.Manual)
        return;
label_1:
      int num1 = 1883344451;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ 1732823914)) % 3U)
        {
          case 0:
            goto label_1;
          case 1:
            this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.throttleInput = 0.0f;
            num1 = (int) num2 * -339474852 ^ 585652368;
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

    private void \u200E‍‪‏⁫⁬‮‬⁮⁬‮‍⁫‬‎‭‍‪⁯⁬‎⁪‍⁭‌⁪‫‪‌‫‌⁮‬⁬⁯⁮‫‫‭‭‮()
    {
      int wheelIndex1 = this.driveline.firstDrivenAxle * 2;
label_1:
      int num1 = 186717233;
      float slip1;
      float angularVelocityForSlip1;
      float wheelFinalRatio;
      int wheelIndex2;
      float slip2;
      float angularVelocityForSlip2;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ 507632388)) % 30U)
        {
          case 0:
            this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.tcsRpms = 0.0f;
            num1 = 1627430472;
            continue;
          case 1:
            this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.tcsRpms = (float) (((double) angularVelocityForSlip1 + (double) angularVelocityForSlip2) * 0.5) * wheelFinalRatio * Block.WToRpm;
            num1 = (int) num2 * 1959586325 ^ -634388615;
            continue;
          case 2:
            int num3;
            num1 = num3 = (double) angularVelocityForSlip1 != 0.0 ? 849546716 : (num3 = 152821770);
            continue;
          case 3:
            num1 = (int) num2 * -1614207120 ^ -670256755;
            continue;
          case 4:
            num1 = (int) num2 * -1217034064 ^ -1944659971;
            continue;
          case 5:
            slip2 = (float) this.GetWheelPeakSlip(wheelIndex2).y;
            num1 = (int) num2 * 1236048539 ^ 531980456;
            continue;
          case 6:
            int num4;
            num1 = num4 = (double) angularVelocityForSlip2 == 0.0 ? 1079164498 : (num4 = 963177044);
            continue;
          case 7:
label_25:
            slip1 = this.tractionControl.customSlip;
            num1 = 207983672;
            continue;
          case 8:
            num1 = (int) num2 * 1954090309 ^ 766027782;
            continue;
          case 9:
            int num5 = (double) angularVelocityForSlip2 == 0.0 ? -636053311 : (num5 = -1220518700);
            num1 = num5 ^ (int) num2 * 1903610189;
            continue;
          case 10:
            this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.tcsRpms = angularVelocityForSlip1 * wheelFinalRatio * Block.WToRpm;
            num1 = (int) num2 * 784982717 ^ -2051288272;
            continue;
          case 11:
            angularVelocityForSlip1 = this.GetWheelAngularVelocityForSlip(wheelIndex1, slip1);
            angularVelocityForSlip2 = this.GetWheelAngularVelocityForSlip(wheelIndex2, slip2);
            num1 = 997647628;
            continue;
          case 12:
            int num6 = (double) angularVelocityForSlip1 == 0.0 ? -1849550204 : (num6 = -76038451);
            num1 = num6 ^ (int) num2 * 320466631;
            continue;
          case 13:
            slip2 = 0.0f;
            switch (this.tractionControl.mode)
            {
              case TractionControl.Mode.Street:
                goto label_5;
              case TractionControl.Mode.Sport:
                goto label_30;
              case TractionControl.Mode.CustomSlip:
                goto label_25;
              default:
                num1 = (int) num2 * -1290901994 ^ 1448922932;
                continue;
            }
          case 14:
            this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.tcsRpms = angularVelocityForSlip2 * wheelFinalRatio * Block.WToRpm;
            num1 = (int) num2 * -746973092 ^ 1449336114;
            continue;
          case 15:
            int num7 = !float.IsNaN(wheelFinalRatio) ? -2141717158 : (num7 = -1739933337);
            num1 = num7 ^ (int) num2 * -550641453;
            continue;
          case 16:
            slip1 = -slip1;
            num1 = (int) num2 * 538126022 ^ 392090726;
            continue;
          case 17:
            wheelIndex2 = wheelIndex1 + 1;
            wheelFinalRatio = this.GetWheelFinalRatio(wheelIndex1);
            num1 = (int) num2 * -128267346 ^ 607830167;
            continue;
          case 18:
            this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.tcsRatio = 0.0f;
            num1 = (int) num2 * 1048989082 ^ -889783559;
            continue;
          case 19:
            slip1 = 0.0f;
            num1 = 1683173043;
            continue;
          case 20:
            slip2 = -slip2;
            num1 = (int) num2 * -1495505274 ^ -2105729669;
            continue;
          case 21:
            slip2 = (float) this.GetWheelAdherentSlip(wheelIndex2).y;
            num1 = (int) num2 * -1938808160 ^ -814399717;
            continue;
          case 23:
            goto label_3;
          case 24:
label_30:
            slip1 = (float) this.GetWheelPeakSlip(wheelIndex1).y;
            num1 = 9677493;
            continue;
          case 25:
label_5:
            slip1 = (float) this.GetWheelAdherentSlip(wheelIndex1).y;
            num1 = 239587879;
            continue;
          case 26:
            goto label_1;
          case 27:
            num1 = (int) num2 * 937024217 ^ -2030505358;
            continue;
          case 28:
            slip2 = this.tractionControl.customSlip;
            num1 = (int) num2 * 537587911 ^ -1902133575;
            continue;
          case 29:
            int num8;
            num1 = num8 = (double) wheelFinalRatio >= 0.0 ? 1943440911 : (num8 = 1559831742);
            continue;
          default:
            goto label_32;
        }
      }
label_3:
      return;
label_32:
      this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.tcsRatio = this.tractionControl.ratio;
    }

    private void \u200D‮‏‮⁬​​⁭‭⁭⁮⁫‎‬‍‭‭‌⁯‫‬‏‮‭‌‪⁪⁯⁪‍‭‎​‫⁭‎‏⁯‪‬‮(ref float _param1)
    {
      if (this.steeringAids.priority != SteeringAids.Priority.PreferDrifting)
        goto label_4;
label_1:
      int num1 = -1477419425;
label_2:
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -1400044865)) % 6U)
        {
          case 0:
            goto label_1;
          case 1:
            goto label_4;
          case 2:
            this.\u206E⁭‎‍‌⁬‏‭‪⁯‪⁪‭‮‬‌‌‭‮⁯‏⁯​⁮‏‎‭‭⁪⁮‎‪‪⁭⁯‪‍‌‏⁯‮(ref _param1);
            num1 = (int) num2 * -190617910 ^ 577707136;
            continue;
          case 3:
            this.\u206A‮‬‮⁭‭⁬⁪‫‪​‭⁮‪‍⁭‏⁯⁯⁭⁭‌⁮‏⁫‭⁯⁯⁪​​​‫⁮‎⁭⁪‪‮‮‮(ref _param1);
            num1 = (int) num2 * 1981262746 ^ -373135631;
            continue;
          case 4:
            goto label_3;
          default:
            goto label_7;
        }
      }
label_3:
      return;
label_7:
      this.\u206E⁭‎‍‌⁬‏‭‪⁯‪⁪‭‮‬‌‌‭‮⁯‏⁯​⁮‏‎‭‭⁪⁮‎‪‪⁭⁯‪‍‌‏⁯‮(ref _param1);
      return;
label_4:
      this.\u206A‮‬‮⁭‭⁬⁪‫‪​‭⁮‪‍⁭‏⁯⁯⁭⁭‌⁮‏⁫‭⁯⁯⁪​​​‫⁮‎⁭⁪‪‮‮‮(ref _param1);
      num1 = -253804022;
      goto label_2;
    }

    private void \u206E⁭‎‍‌⁬‏‭‪⁯‪⁪‭‮‬‌‌‭‮⁯‏⁯​⁮‏‎‭‭⁪⁮‎‪‪⁭⁯‪‍‌‏⁯‮(ref float _param1)
    {
      if (this.steeringAids.helpMode == SteeringAids.HelpMode.Disabled)
        return;
label_1:
      int num1 = -1177010478;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -1223573221)) % 4U)
        {
          case 0:
            goto label_6;
          case 1:
            int num3 = (double) this.steeringAids.helpRatio > 0.0 ? -803119861 : (num3 = -2104863084);
            num1 = num3 ^ (int) num2 * 7017067;
            continue;
          case 2:
            goto label_1;
          case 3:
            float num4 = Mathf.Clamp(this.speedAngle * this.steeringAids.helpRatio * Mathf.InverseLerp(0.1f, 3f, this.speed) * Mathf.InverseLerp(2f, 3f, Mathf.Abs(this.speedAngle)) / this.steering.maxSteerAngle, -1f, 1f);
            _param1 = num4 + _param1;
            num1 = (int) num2 * 710169461 ^ -2028312264;
            continue;
          default:
            goto label_7;
        }
      }
label_6:
      return;
label_7:;
    }

    private void \u206A‮‬‮⁭‭⁬⁪‫‪​‭⁮‪‍⁭‏⁯⁯⁭⁭‌⁮‏⁫‭⁯⁯⁪​​​‫⁮‎⁭⁪‪‮‮‮(ref float _param1)
    {
      if (this.steeringAids.limitMode == SteeringAids.LimitMode.Disabled)
        return;
label_1:
      int num1 = 1780681169;
      float num2;
      float num3;
      while (true)
      {
        uint num4;
        float num5;
        float num6;
        float num7;
        float num8;
        float num9;
        float num10;
        float num11;
        int wheelIndex1;
        int wheelIndex2;
        double num12;
        switch ((num4 = (uint) (num1 ^ 25629188)) % 28U)
        {
          case 0:
            int num13 = (double) num11 < (double) this.speedAngle ? 557794729 : (num13 = 1988672177);
            num1 = num13 ^ (int) num4 * -646212290;
            continue;
          case 1:
label_31:
            num9 = (float) ((this.GetWheelPeakSlip(wheelIndex1).x + this.GetWheelPeakSlip(wheelIndex2).x) * 0.5);
            num1 = 2077347919;
            continue;
          case 2:
            num8 = this.speedAngle;
            num1 = (int) num4 * -1818399272 ^ -1018151983;
            continue;
          case 3:
            int num14 = (double) this.speedAngle <= 0.0 ? -1165613714 : (num14 = -1769504406);
            num1 = num14 ^ (int) num4 * -835338406;
            continue;
          case 5:
            _param1 = num6 = _param1 * -num5;
            num1 = (int) num4 * -589676379 ^ -207537937;
            continue;
          case 6:
            num12 = (double) num6;
            break;
          case 7:
            wheelIndex2 = wheelIndex1 + 1;
            num9 = 0.0f;
            num1 = (int) num4 * -865657018 ^ 1844170326;
            continue;
          case 8:
            switch (this.steeringAids.limitMode)
            {
              case SteeringAids.LimitMode.Street:
                goto label_24;
              case SteeringAids.LimitMode.Sport:
                goto label_31;
              case SteeringAids.LimitMode.CustomSlip:
                goto label_11;
              default:
                num1 = (int) num4 * -1799869404 ^ -1772673046;
                continue;
            }
          case 9:
            int num15;
            num1 = num15 = (double) num11 <= (double) this.steering.maxSteerAngle ? 786155655 : (num15 = 792580533);
            continue;
          case 10:
            goto label_1;
          case 11:
            num10 = this.speed;
            int num16;
            num1 = num16 = (double) num10 >= 0.0 ? 497960217 : (num16 = 65940538);
            continue;
          case 12:
            num8 = -this.steering.maxSteerAngle;
            num1 = (int) num4 * 1151127239 ^ 325478399;
            continue;
          case 13:
            num11 = this.speedAngle;
            num1 = (int) num4 * 882003584 ^ -276446719;
            continue;
          case 14:
            wheelIndex1 = this.\u202C⁪​‬⁯‬​⁭‪⁪‫‫⁯⁮‮‪‭‮⁮‭‪⁫‎‍⁯⁪⁬‫⁬‏​⁮‎​‏‪‬‏⁪‌‮ * 2;
            num1 = 7587367;
            continue;
          case 15:
label_24:
            num9 = (float) ((this.GetWheelAdherentSlip(wheelIndex1).x + this.GetWheelAdherentSlip(wheelIndex2).x) * 0.5);
            num1 = 2077347919;
            continue;
          case 16:
            num5 = num8 / this.steering.maxSteerAngle;
            num3 = Mathf.Clamp(_param1, num5, num7);
            num1 = (int) num4 * -700560777 ^ 1234504524;
            continue;
          case 17:
            num11 = this.steering.maxSteerAngle;
            num1 = (int) num4 * -1500431826 ^ 2113768265;
            continue;
          case 18:
            num10 = 0.0f;
            num1 = (int) num4 * 858896886 ^ -1084958579;
            continue;
          case 19:
label_11:
            num9 = this.steeringAids.limitCustomSlip;
            num1 = 2077347919;
            continue;
          case 20:
            int num17;
            num1 = num17 = (double) this.speedAngle < (double) num8 ? 1644011866 : (num17 = 1675388545);
            continue;
          case 21:
            int num18 = (double) this.steeringAids.limitRatio > 0.0 ? -592406810 : (num18 = -904489102);
            num1 = num18 ^ (int) num4 * -1880207568;
            continue;
          case 22:
            goto label_34;
          case 23:
            int num19;
            num1 = num19 = (double) num8 >= -(double) this.steering.maxSteerAngle ? 1491541183 : (num19 = 754940100);
            continue;
          case 24:
            if ((double) _param1 >= 0.0)
            {
              num12 = (double) _param1 * (double) num7;
              break;
            }
            num1 = (int) num4 * -1478699013 ^ 2024724321;
            continue;
          case 25:
            num8 = -(num11 = Mathf.Asin(Mathf.Clamp01(num9 / (num10 * this.steeringAids.limitRatio))) * 57.29578f);
            num1 = 1223553579;
            continue;
          case 26:
            num1 = (int) num4 * 860761311 ^ 1320022301;
            continue;
          case 27:
            num7 = num11 / this.steering.maxSteerAngle;
            num1 = 1832416164;
            continue;
          default:
            goto label_33;
        }
        num2 = (float) num12;
        num1 = 441015184;
      }
label_34:
      return;
label_33:
      _param1 = Mathf.Lerp(num3, num2, this.steeringAids.limitProportionality);
    }

    private float \u202B⁮⁯⁫‪⁫‎‎‎‫⁭⁯‎⁪⁮‎⁬‬‪‌⁪⁭⁬‬‭⁪‬⁭‎‪‮‎⁯‫‬⁪‪‍⁯⁮‮(float _param1)
    {
      if (this.speedControl.cruiseControl)
        goto label_16;
label_1:
      int num1 = 1163546833;
label_2:
      int num2;
      float num3;
      float num4;
      bool flag1;
      float num5;
      bool flag2;
      bool flag3;
      while (true)
      {
        uint num6;
        bool flag4;
        bool flag5;
        int num7;
        switch ((num6 = (uint) (num1 ^ 993456879)) % 17U)
        {
          case 0:
            int num8 = num2 <= 0 ? -181122937 : (num8 = -2042754099);
            num1 = num8 ^ (int) num6 * 474267486;
            continue;
          case 1:
            int num9 = this.speedControl.speedLimiter ? -1747644498 : (num9 = -226616909);
            num1 = num9 ^ (int) num6 * 500959098;
            continue;
          case 2:
            num3 = Mathf.Clamp01((this.speedControl.cruiseSpeed - num5) * this.speedControl.throttleSlope);
            num1 = (int) num6 * -172764016 ^ -350434299;
            continue;
          case 3:
            int num10 = !flag1 ? 2047800757 : (num10 = 652582053);
            num1 = num10 ^ (int) num6 * 2009000350;
            continue;
          case 4:
            num3 = 0.0f;
            if (this.speedControl.cruiseControl)
            {
              num1 = (int) num6 * -395834369 ^ 24076067;
              continue;
            }
            num7 = 0;
            break;
          case 5:
            int num11 = !flag4 ? -870686759 : (num11 = -1342707425);
            num1 = num11 ^ (int) num6 * -1132341730;
            continue;
          case 6:
            num4 = Mathf.Clamp01((this.speedControl.speedLimit - num5) * this.speedControl.throttleSlope);
            num1 = (int) num6 * -1004241816 ^ 850112817;
            continue;
          case 7:
            goto label_1;
          case 8:
            goto label_16;
          case 9:
            goto label_10;
          case 10:
            int num12 = flag3 ? -503231825 : (num12 = -697451338);
            num1 = num12 ^ (int) num6 * -733689927;
            continue;
          case 11:
            num4 = 1f;
            num1 = 1846467822;
            continue;
          case 12:
            int[] numArray = this.data.Get(0);
            flag4 = numArray[2] > 1000;
            flag5 = numArray[4] > 1000;
            num1 = (int) num6 * 799954422 ^ 182647288;
            continue;
          case 13:
            int num13 = !flag5 ? 1554307233 : (num13 = 109127985);
            num1 = num13 ^ (int) num6 * -1766868521;
            continue;
          case 15:
            num7 = (double) num5 >= (double) this.speedControl.minSpeedForCC ? 1 : 0;
            break;
          case 16:
            int num14 = !this.speedControl.speedLimiter ? -2060289432 : (num14 = -711128966);
            num1 = num14 ^ (int) num6 * 582999591;
            continue;
          default:
            goto label_21;
        }
        int num15 = flag2 ? 1 : 0;
        int num16;
        num1 = num16 = (num7 & num15) == 0 ? 2019794597 : (num16 = 1680253904);
      }
label_10:
      return _param1;
label_21:
      return Mathf.Min(Mathf.Max(_param1, num3), num4);
label_16:
      int[] numArray1 = this.data.Get(1);
      num5 = (float) numArray1[0] / 1000f;
      flag2 = (uint) numArray1[3] > 0U;
      num2 = numArray1[12];
      flag1 = numArray1[14] != 0 && this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.settings.type == Gearbox.Type.Manual;
      flag3 = numArray1[15] > 0;
      num1 = 1273162872;
      goto label_2;
    }

    private void \u206A⁭⁭⁭⁮‏‫‮⁭⁬⁭‍‌⁭‬‪‪‮‍⁮⁯‬‫‪‭‎‫⁭‬‌‭⁪​‫‏‬‬‫⁫‬‮()
    {
      this.\u200E‭‎⁪‬​⁭‫⁭⁪⁯‫‌⁫⁯⁬⁬‎⁫‏⁪⁮⁮⁭‏‌⁪⁫‌‪⁪‫⁬‭‫⁪⁮‬​‫‮.stateVehicleSpeed = this.speed;
      this.\u200E‭‎⁪‬​⁭‫⁭⁪⁯‫‌⁫⁯⁬⁬‎⁫‏⁪⁮⁮⁭‏‌⁪⁫‌‪⁪‫⁬‭‫⁪⁮‬​‫‮.stateVehicleSpeedAngle = this.speedAngle;
label_1:
      int num1 = -55214718;
      float num2;
      while (true)
      {
        uint num3;
        switch ((num3 = (uint) (num1 ^ -1333787675)) % 12U)
        {
          case 0:
            this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.throttleInput *= 1f - num2;
            this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.clutchInput = Mathf.Max(this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.clutchInput, num2);
            num1 = (int) num3 * 338350381 ^ 1910417381;
            continue;
          case 1:
            int num4 = (double) num2 > 0.0 ? -996293839 : (num4 = -2109304143);
            num1 = num4 ^ (int) num3 * 1197904772;
            continue;
          case 2:
            int num5 = !this.stabilityControl.enabled ? -363162967 : (num5 = -953463516);
            num1 = num5 ^ (int) num3 * -936635865;
            continue;
          case 3:
            this.\u200B‭⁭​‌⁬‭⁪‮⁪‪‫‌‌‪‫⁪⁮⁮⁮⁫‭⁪‭⁫‫‏​⁪⁮⁫‍⁫‎⁬‬‬‏‌‌‮.AddBrakeRatio(this.\u200E‭‎⁪‬​⁭‫⁭⁪⁯‫‌⁫⁯⁬⁬‎⁫‏⁪⁮⁮⁭‏‌⁪⁫‌‪⁪‫⁬‭‫⁪⁮‬​‫‮.sensorBrakeFL, Brakes.BrakeCircuit.Front, Brakes.LateralPosition.Left);
            this.\u200B‭⁭​‌⁬‭⁪‮⁪‪‫‌‌‪‫⁪⁮⁮⁮⁫‭⁪‭⁫‫‏​⁪⁮⁫‍⁫‎⁬‬‬‏‌‌‮.AddBrakeRatio(this.\u200E‭‎⁪‬​⁭‫⁭⁪⁯‫‌⁫⁯⁬⁬‎⁫‏⁪⁮⁮⁭‏‌⁪⁫‌‪⁪‫⁬‭‫⁪⁮‬​‫‮.sensorBrakeFR, Brakes.BrakeCircuit.Front, Brakes.LateralPosition.Right);
            num1 = -477013603;
            continue;
          case 4:
            this.\u200B‭⁭​‌⁬‭⁪‮⁪‪‫‌‌‪‫⁪⁮⁮⁮⁫‭⁪‭⁫‫‏​⁪⁮⁫‍⁫‎⁬‬‬‏‌‌‮.AddBrakeRatio(this.\u200E‭‎⁪‬​⁭‫⁭⁪⁯‫‌⁫⁯⁬⁬‎⁫‏⁪⁮⁮⁭‏‌⁪⁫‌‪⁪‫⁬‭‫⁪⁮‬​‫‮.sensorBrakeRL, Brakes.BrakeCircuit.Rear, Brakes.LateralPosition.Left);
            num1 = (int) num3 * -1533797399 ^ 1621932290;
            continue;
          case 5:
            goto label_1;
          case 6:
            num2 = Mathf.Clamp01(Mathf.Max(Mathf.Max(this.\u200E‭‎⁪‬​⁭‫⁭⁪⁯‫‌⁫⁯⁬⁬‎⁫‏⁪⁮⁮⁭‏‌⁪⁫‌‪⁪‫⁬‭‫⁪⁮‬​‫‮.sensorBrakeFL, this.\u200E‭‎⁪‬​⁭‫⁭⁪⁯‫‌⁫⁯⁬⁬‎⁫‏⁪⁮⁮⁭‏‌⁪⁫‌‪⁪‫⁬‭‫⁪⁮‬​‫‮.sensorBrakeFR), Mathf.Max(this.\u200E‭‎⁪‬​⁭‫⁭⁪⁯‫‌⁫⁯⁬⁬‎⁫‏⁪⁮⁮⁭‏‌⁪⁫‌‪⁪‫⁬‭‫⁪⁮‬​‫‮.sensorBrakeRL, this.\u200E‭‎⁪‬​⁭‫⁭⁪⁯‫‌⁫⁯⁬⁬‎⁫‏⁪⁮⁮⁭‏‌⁪⁫‌‪⁪‫⁬‭‫⁪⁮‬​‫‮.sensorBrakeRR)));
            num1 = (int) num3 * -1061103908 ^ -65065472;
            continue;
          case 7:
            this.\u200E‭‎⁪‬​⁭‫⁭⁪⁯‫‌⁫⁯⁬⁬‎⁫‏⁪⁮⁮⁭‏‌⁪⁫‌‪⁪‫⁬‭‫⁪⁮‬​‫‮.stateVehicleRotationRate = (float) this.cachedRigidbody.get_angularVelocity().y;
            this.\u200E‭‎⁪‬​⁭‫⁭⁪⁯‫‌⁫⁯⁬⁬‎⁫‏⁪⁮⁮⁭‏‌⁪⁫‌‪⁪‫⁬‭‫⁪⁮‬​‫‮.stateVehicleSteeringAngle = this.steering.maxSteerAngle * this.\u202E⁯⁯⁭⁭‌‎⁭‭‮⁬⁫⁬⁫‭⁭⁪‫‭‌⁮‏‬‭⁪​‎‭‎‏⁬⁮⁯⁪⁮⁮‮​⁪‌‮.steerInput;
            this.\u200E‭‎⁪‬​⁭‫⁭⁪⁯‫‌⁫⁯⁬⁬‎⁫‏⁪⁮⁮⁭‏‌⁪⁫‌‪⁪‫⁬‭‫⁪⁮‬​‫‮.DoUpdate();
            num1 = (int) num3 * 768854482 ^ 38905141;
            continue;
          case 8:
            goto label_10;
          case 9:
            int num6 = this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮ != null ? 1662475538 : (num6 = 935643440);
            num1 = num6 ^ (int) num3 * 1137024145;
            continue;
          case 10:
            goto label_3;
          case 11:
            this.\u200B‭⁭​‌⁬‭⁪‮⁪‪‫‌‌‪‫⁪⁮⁮⁮⁫‭⁪‭⁫‫‏​⁪⁮⁫‍⁫‎⁬‬‬‏‌‌‮.AddBrakeRatio(this.\u200E‭‎⁪‬​⁭‫⁭⁪⁯‫‌⁫⁯⁬⁬‎⁫‏⁪⁮⁮⁭‏‌⁪⁫‌‪⁪‫⁬‭‫⁪⁮‬​‫‮.sensorBrakeRR, Brakes.BrakeCircuit.Rear, Brakes.LateralPosition.Right);
            num1 = (int) num3 * 57460784 ^ -2083795312;
            continue;
          default:
            goto label_14;
        }
      }
label_10:
      return;
label_3:
      return;
label_14:;
    }

    private void \u202E​‫‪⁬⁪⁯‭⁫‬‍‪⁪⁬⁮‏​‬‭‫‏‫‪⁯⁫⁭⁬⁪⁯⁪‌⁭‮‪‎⁪‮‏⁭⁫‮()
    {
      int index1 = this.driveline.firstDrivenAxle * 2;
label_1:
      int num1 = -856497919;
      int index2;
      while (true)
      {
        uint num2;
        switch ((num2 = (uint) (num1 ^ -994261650)) % 6U)
        {
          case 0:
            goto label_1;
          case 1:
            this.\u206E⁭⁬‍​‭⁭‏‮‎‏⁯⁫‌‌​‮‪‌‍‬‍‌‎‏⁭​‬‏⁪⁬‫⁪⁬‬‪⁪‫⁮⁬‮.stateAngularVelocityR = this.wheelState[index2].angularVelocity;
            this.\u206E⁭⁬‍​‭⁭‏‮‎‏⁯⁫‌‌​‮‪‌‍‬‍‌‎‏⁭​‬‏⁪⁬‫⁪⁬‬‪⁪‫⁮⁬‮.DoUpdate();
            num1 = (int) num2 * 2140833086 ^ -1849968546;
            continue;
          case 2:
            goto label_3;
          case 4:
            int num3 = this.antiSpin.enabled ? -767400359 : (num3 = -1473209690);
            num1 = num3 ^ (int) num2 * 858458291;
            continue;
          case 5:
            index2 = index1 + 1;
            this.\u206E⁭⁬‍​‭⁭‏‮‎‏⁯⁫‌‌​‮‪‌‍‬‍‌‎‏⁭​‬‏⁪⁬‫⁪⁬‬‪⁪‫⁮⁬‮.stateVehicleSpeed = this.speed;
            this.\u206E⁭⁬‍​‭⁭‏‮‎‏⁯⁫‌‌​‮‪‌‍‬‍‌‎‏⁭​‬‏⁪⁬‫⁪⁬‬‪⁪‫⁮⁬‮.stateAngularVelocityL = this.wheelState[index1].angularVelocity;
            num1 = (int) num2 * -840347573 ^ 1698273752;
            continue;
          default:
            goto label_7;
        }
      }
label_3:
      return;
label_7:
      double num4 = (double) this.wheels[index1].AddBrakeTorque(this.\u206E⁭⁬‍​‭⁭‏‮‎‏⁯⁫‌‌​‮‪‌‍‬‍‌‎‏⁭​‬‏⁪⁬‫⁪⁬‬‪⁪‫⁮⁬‮.sensorBrakeTorqueL);
      double num5 = (double) this.wheels[index2].AddBrakeTorque(this.\u206E⁭⁬‍​‭⁭‏‮‎‏⁯⁫‌‌​‮‪‌‍‬‍‌‎‏⁭​‬‏⁪⁬‫⁪⁬‬‪⁪‫⁮⁬‮.sensorBrakeTorqueR);
    }

    public float GetOptimalGearShiftRatio()
    {
      if (this.initialized)
      {
label_1:
        int num1 = 1950534661;
        float num2;
        float num3;
        float torque;
        float axleFinalRatio;
        float gearRatio1;
        float num4;
        float sensorRpm;
        float num5;
        int sensorEngagedGear;
        int length;
        float gearRatio2;
        float gearRatio3;
        float rpm1;
        while (true)
        {
          uint num6;
          switch ((num6 = (uint) (num1 ^ 664075979)) % 27U)
          {
            case 1:
              int num7;
              num1 = num7 = (double) num2 > (double) num3 ? 1279392285 : (num7 = 1864901752);
              continue;
            case 2:
              torque = this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.CalculateTorque(sensorRpm, this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.throttleInput);
              int num8 = (double) torque <= 0.0 ? 1302304063 : (num8 = 193839607);
              num1 = num8 ^ (int) num6 * -1998233259;
              continue;
            case 3:
              int num9;
              num1 = num9 = (double) this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.throttleInput < 0.5 ? 2094055194 : (num9 = 1643022220);
              continue;
            case 4:
              num3 = axleFinalRatio * gearRatio3 * this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.CalculateTorque(rpm1, this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.throttleInput) / num4;
              num1 = (int) num6 * -871537252 ^ 1853214584;
              continue;
            case 5:
              gearRatio2 = this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.GetGearRatio(sensorEngagedGear - 1);
              num1 = (int) num6 * -1418444406 ^ 155609729;
              continue;
            case 6:
              int num10 = sensorEngagedGear < length ? -1502563206 : (num10 = -292393420);
              num1 = num10 ^ (int) num6 * 407725598;
              continue;
            case 7:
              gearRatio1 = this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.GetGearRatio(sensorEngagedGear);
              num1 = (int) num6 * -1198490636 ^ -1797418726;
              continue;
            case 8:
              int num11;
              num1 = num11 = sensorEngagedGear > 1 ? 1488477912 : (num11 = 1406658724);
              continue;
            case 9:
              int num12 = this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮ != null ? 881523626 : (num12 = 780310486);
              num1 = num12 ^ (int) num6 * 110961734;
              continue;
            case 10:
              goto label_5;
            case 11:
              int num13 = sensorEngagedGear <= 0 ? 1856037428 : (num13 = 2144565179);
              num1 = num13 ^ (int) num6 * -1369351084;
              continue;
            case 12:
              sensorRpm = this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.sensorRpm;
              num1 = 1508575664;
              continue;
            case 13:
              float rpm2 = num5 * axleFinalRatio * gearRatio2;
              num2 = axleFinalRatio * gearRatio2 * this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.CalculateTorque(rpm2, this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮.throttleInput) / num4;
              num1 = (int) num6 * -2104534907 ^ 1899209184;
              continue;
            case 14:
              length = this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.settings.forwardGearRatios.Length;
              int num14;
              num1 = num14 = length < 2 ? 568899628 : (num14 = 386905029);
              continue;
            case 15:
              sensorEngagedGear = this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.sensorEngagedGear;
              num1 = 2106410895;
              continue;
            case 16:
              gearRatio3 = this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.GetGearRatio(sensorEngagedGear + 1);
              num1 = (int) num6 * -305411265 ^ 901203486;
              continue;
            case 17:
              goto label_6;
            case 18:
              goto label_1;
            case 19:
              goto label_24;
            case 20:
              num4 = torque * axleFinalRatio * gearRatio1;
              num5 = sensorRpm / axleFinalRatio / gearRatio1;
              num3 = 0.0f;
              num2 = 0.0f;
              num1 = (int) num6 * 186769280 ^ -374122015;
              continue;
            case 21:
              goto label_4;
            case 22:
              rpm1 = num5 * axleFinalRatio * gearRatio3;
              num1 = (int) num6 * 709697964 ^ 1002917275;
              continue;
            case 23:
              goto label_12;
            case 24:
              goto label_16;
            case 25:
              int num15 = this.\u202A‏⁪⁮‮⁬⁪⁭‌‬‌‎‎‪‏⁪⁪‎⁮​⁫‪⁪‏‏⁭‬⁭⁪⁭‭‬‎‭⁬‭⁬‪‌‭‮ == null ? 1747619534 : (num15 = 1927120587);
              num1 = num15 ^ (int) num6 * 896593452;
              continue;
            case 26:
              axleFinalRatio = this.\u206C‎‎‬‮⁫​‏⁪⁭⁫⁯‫‌‎‫⁪‍⁪⁭⁬​⁮‌‭⁭‪‭‪‎‏⁯⁫⁮‍⁫‪‌⁬‎‮.GetAxleFinalRatio(this.driveline.firstDrivenAxle);
              num1 = 984629428;
              continue;
            default:
              goto label_28;
          }
        }
label_4:
        return 0.0f;
label_5:
        return 0.0f;
label_6:
        return 0.0f;
label_12:
        return 0.0f;
label_24:
        return -num2;
label_28:
        return num3;
      }
label_16:
      return 0.0f;
    }

    public float GetWheelFinalRatio(int wheelIndex, int gear = 0)
    {
      if (this.initialized)
      {
label_1:
        int num1 = 1737180074;
        float axleFinalRatio;
        while (true)
        {
          uint num2;
          switch ((num2 = (uint) (num1 ^ 696615551)) % 11U)
          {
            case 0:
              goto label_1;
            case 1:
              axleFinalRatio *= this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.GetGearRatio(gear);
              num1 = 338725261;
              continue;
            case 2:
              num1 = (int) num2 * -1649595218 ^ -854933037;
              continue;
            case 3:
              int num3 = this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮ != null ? 1355142233 : (num3 = 905833455);
              num1 = num3 ^ (int) num2 * -320593702;
              continue;
            case 4:
              axleFinalRatio *= this.\u202D‌‍‫‭‭‮⁯‏‭⁮‎‫⁮​​‬⁭⁪‮‍⁪⁬‭‍‭‎‮​‫‭‍​⁪​‌‫⁮‪‎‮.GetCurrentGearRatio();
              num1 = (int) num2 * 1062387513 ^ -94194515;
              continue;
            case 5:
              axleFinalRatio = this.\u206C‎‎‬‮⁫​‏⁪⁭⁫⁯‫‌‎‫⁪‍⁪⁭⁬​⁮‌‭⁭‪‭‪‎‏⁯⁫⁮‍⁫‪‌⁬‎‮.GetAxleFinalRatio(wheelIndex / 2);
              num1 = 1379242794;
              continue;
            case 6:
              goto label_7;
            case 7:
              int num4 = wheelIndex < this.wheels.Length ? 1555711705 : (num4 = 1552494090);
              num1 = num4 ^ (int) num2 * -62334648;
              continue;
            case 8:
              int num5 = gear != 0 ? -1374491775 : (num5 = -462755720);
              num1 = num5 ^ (int) num2 * 796842165;
              continue;
            case 10:
              int num6 = wheelIndex < 0 ? 869580270 : (num6 = 1850166946);
              num1 = num6 ^ (int) num2 * -943160196;
              continue;
            default:
              goto label_12;
          }
        }
label_12:
        return axleFinalRatio;
      }
label_7:
      return 0.0f;
    }

    private void OnDrawGizmos()
    {
    }
  }
}
*/