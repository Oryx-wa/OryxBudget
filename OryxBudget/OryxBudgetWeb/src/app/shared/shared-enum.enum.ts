
export enum DisplayModeEnum {
  Card = 0,
  Grid = 1,
  Map = 2,
  Edit = 3,
  Details = 4,
  Create = 5,
  Upload = 6,
  Option1 = 7,
  Option2 = 8,
  Option3 = 9,
  Option4 = 10
}

export function trackByFn(index, item) {
  return item.id;
}
