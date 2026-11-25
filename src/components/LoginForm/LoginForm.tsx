import { Button } from '@/UI/Button/Button'
import { TextField } from '@/UI/TextField/TextField'

import styles from './LoginForm.module.scss'

export function LoginForm() {
  const { values, touched, errors, canSubmit, submitted, changeField, blurField, handleSubmit } =
    useLoginForm()

  return (
    <form className={styles.card} aria-label="Вход в аккаунт" onSubmit={handleSubmit} noValidate>
      <TextField
        label="ID"
        name="userId"
        placeholder="Введите ID"
        autoComplete="username"
        autoCapitalize="none"
        spellCheck={false}
        required
        value={values.userId}
        onChange={(event) => changeField('userId', event.target.value)}
        onBlur={() => blurField('userId')}
        error={touched.userId ? errors.userId : undefined}
      />
      <TextField
        label="Пароль"
        name="password"
        type="password"
        placeholder="Введите пароль"
        autoComplete="current-password"
        required
        value={values.password}
        onChange={(event) => changeField('password', event.target.value)}
        onBlur={() => blurField('password')}
        error={touched.password ? errors.password : undefined}
      />
      <div className={styles.action}>
        <Button type="submit" disabled={!canSubmit}>
          Войти
        </Button>
      </div>
      <div role="status" aria-live="polite">
        {submitted && <p className={styles.status}>Поля заполнены. Вход пока недоступен.</p>}
      </div>
    </form>
  )
}
import { useLoginForm } from '@/hooks/useLoginForm'
