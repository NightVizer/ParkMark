import type { ComponentPropsWithoutRef } from 'react'

import styles from './Button.module.scss'

export function Button({
  className = '',
  type = 'button',
  ...props
}: ComponentPropsWithoutRef<'button'>) {
  return <button className={`${styles.button} ${className}`} type={type} {...props} />
}
