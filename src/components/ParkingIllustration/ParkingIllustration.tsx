import bays from '@/UI/assets/parking-bays.svg'
import rail from '@/UI/assets/parking-rail.svg'
import post from '@/UI/assets/parking-post.svg'
import road from '@/UI/assets/parking-road.svg'
import highlight from '@/UI/assets/parking-highlight.svg'
import carLeft from '@/UI/assets/car-left.svg'
import carRight from '@/UI/assets/car-right.svg'
import carActive from '@/UI/assets/car-active.svg'

import styles from './ParkingIllustration.module.scss'

export function ParkingIllustration() {
  return (
    <svg className={styles.illustration} viewBox="0 0 448 132" aria-hidden="true" focusable="false">
      <image href={bays} x="6.5" y="6.5" width="435" height="95" />
      <image href={rail} x="6" y="6" width="436" height="4" />
      <image href={post} x="87.9" y="1.5" width="13" height="13" />
      <image href={post} x="347.1" y="1.5" width="13" height="13" />
      <image href={road} y="122" width="448" height="4" />
      <image
        href={carLeft}
        x="-39.3"
        y="-18.9"
        width="78.6"
        height="37.8"
        transform="translate(51.2 56) rotate(-90)"
      />
      <image
        href={carRight}
        x="-39.3"
        y="-18.9"
        width="78.6"
        height="37.8"
        transform="translate(310.4 56) rotate(-90)"
      />
      <image href={highlight} x="186.8" y="14" width="74.4" height="82" />
      <image
        href={carActive}
        x="-39.3"
        y="-18.9"
        width="78.6"
        height="37.8"
        transform="translate(224 56) rotate(-90)"
      />
    </svg>
  )
}
