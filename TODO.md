# TODO List
## Backlog
- [ ] Polish
- [ ] Object Pool

## Planned
- [ ] Upgrades
- [ ] Level Generation
- [ ] Rework Perk System
- [ ] Random Ball Start Angle
- [ ] Multiple Ball Perk
- [ ] Sticky Paddle Perk

## Sprint
- [ ] Ball Manager - speedytosbaga
  - Remove everything related with balls from LevelManager
  - BallManager should communicate with LevelManager with events
  - On level ending events, destroy all active balls
  - When no balls left, raise an event, which LevelManager will listen to and trigger level fail
- [ ] Basic Level Generation - k44n
  - Just generate ordinary blocks with different formations

## Done
- [x] Deadzone - speedytosbaga
- [x] End Screen - speedytosbaga
- [x] Random Perk Dropper - k44n
- [x] Larger/Smaller Paddle Perk - k44n
- [x] Ball Speed Increase/Decrease Perk - k44n
- [x] Restart button - speedytosbaga
- [x] Start UI - k44n
- [x] Player Health - speedytosbaga
- [x] Laser Paddle Perk - k44n
- [x] Level Completed Scene - k44n
- [x] Time Pressure - speedytosbaga
- [x] Heads-Up Display (HUD) - speedytosbaga
- [x] Code Refactor - k44n
- [x] Portals - speedytosbaga
