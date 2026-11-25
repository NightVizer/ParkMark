import background from '@/UI/assets/logo-background.svg'
import letter from '@/UI/assets/logo-letter.svg'

import styles from './Logo.module.scss'

export function Logo() {
  return (
    <span className={styles.logo} role="img" aria-label="Т-Банк">
      <img src={background} alt="" />
      <span className={styles.shine} />
      <img className={styles.letter} src={letter} alt="" />
    </span>
  )
}
