import { Logo } from '@/UI/Logo/Logo'
import { LoginForm } from '@/components/LoginForm/LoginForm'
import { ParkingIllustration } from '@/components/ParkingIllustration/ParkingIllustration'

import styles from './LoginPage.module.scss'

export function LoginPage() {
  return (
    <main className={styles.page}>
      <div className={styles.content}>
        <Logo />
        <h1 className={styles.title}>ParkMark</h1>
        <ParkingIllustration />
        <LoginForm />
      </div>
    </main>
  )
}
